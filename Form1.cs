using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initializeDgvShops();
            initializeDgvCity();
            initializeDgvDelivery();
            initializeDgvProviders();
            initializeDgvShops();
        }
        Dictionary<int, string> listProviders = new Dictionary<int, string>();
        Dictionary<int, string> listCity = new Dictionary<int, string>();
        Dictionary<int, string> listAddress = new Dictionary<int, string>();
        private void initializeDgvDelivery()
        {
            dgvDelivery.Rows.Clear();
            dgvDelivery.Columns.Clear();
            dgvDelivery.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_delivery",
                Visible = false
            });
            var address_ = new DataGridViewComboBoxColumn
            {
                HeaderText = @"Адрес магазина",
                Name = "address"
            };
            dgvDelivery.Columns.Add(address_);
            var nameProv = new DataGridViewComboBoxColumn
            {
                HeaderText = @"Поставщик",
                Name = "nameProv"
            };
            dgvDelivery.Columns.Add(nameProv);
            dgvDelivery.Columns.Add(new CalendarColumn
            {
                Name = "DateDelivery",
                HeaderText = @"Дата поставки"
            });

            using (var ctx = new DeliveryContext())
            {
                listProviders.Clear();
                foreach (var provName in ctx.Providers)
                {
                    listProviders.Add(provName.id_provider, provName.name);
                }
                nameProv.DataSource = listProviders.Values.ToList();
                listAddress.Clear();
                foreach (var shop in ctx.Shops)
                {
                    listAddress.Add(shop.id_shop, (string)shop.address + " (" + listCity[shop.id_city] + ")");
                }
                address_.DataSource = listAddress.Values.ToList();
                foreach (var delivery_ in ctx.Deliveries)
                {
                    foreach (var shop in ctx.Shops)
                    {
                        if (delivery_.id_shop == shop.id_shop)
                        {
                            var rowIndex = dgvDelivery.Rows.Add(delivery_.id_delivery, listAddress[shop.id_shop], listProviders[delivery_.id_provider], delivery_.deliveryDate);
                            dgvDelivery.Rows[rowIndex].Tag = delivery_;
                            break;
                        }
                    }
                }

            }
        }

        private void dgvDelivery_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvDelivery.Rows[e.RowIndex];
            var idDelivery = (int?)row.Cells["id_delivery"].Value;
            if (dgvDelivery.IsCurrentRowDirty)
            {
                var cellsWithPotentialErr = new[] { row.Cells["address"], row.Cells["nameProv"] };
                foreach (var cell in cellsWithPotentialErr)
                {
                    if (string.IsNullOrWhiteSpace((string)cell.Value))
                    {
                        row.ErrorText = $"Значчение в столбце'{cell.OwningColumn.HeaderText}' не может быть пустым";
                        e.Cancel = true;
                        break;
                    }
                }
                if (!e.Cancel)
                {
                    var address = (string)row.Cells["address"].Value;
                    var nameProv = (string)row.Cells["nameProv"].Value;
                    var dataDeliv = ((DateTime)row.Cells["DateDelivery"].Value).Date;
                    var q = (Delivery)row.Tag;
                    using (var ctx = new DeliveryContext())
                    {
                        if (idDelivery.HasValue)
                        {
                            ctx.Deliveries.Attach(q);
                            foreach (var item in listAddress)
                                if (item.Value == address)
                                    q.id_shop = item.Key;

                            foreach (var item in listProviders)
                                if (item.Value == nameProv)
                                    q.id_provider = item.Key;
                            q.deliveryDate = dataDeliv;
                            row.Tag = q;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            int idShop=0, idProv=0;
                            foreach (var item in listAddress)
                                if (item.Value == address)
                                    idShop = item.Key;
                            foreach (var item in listProviders)
                                if (item.Value == nameProv)
                                    idProv = item.Key;
                            var delivery = new Delivery
                            {
                                id_shop=idShop,
                                id_provider=idProv,                                
                                deliveryDate=dataDeliv
                            };
                            ctx.Deliveries.Add(delivery);
                            ctx.SaveChanges();
                            row.Tag = delivery;
                            row.Cells["id_delivery"].Value = delivery.id_delivery;
                        }
                    }
                    row.ErrorText = "";
                    foreach (var cell in row.Cells)
                    {
                        ((DataGridViewCell)cell).ErrorText = "";
                    }
                }
            }
        }

        private void dgvDelivery_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var idDelivery = (int?)e.Row.Cells["id_delivery"].Value;
            if (idDelivery.HasValue)
            {
                using (var ctx = new DeliveryContext())
                {
                    try
                    {
                        var delivery = (Delivery)e.Row.Tag;
                        ctx.Deliveries.Attach(delivery);
                        ctx.Deliveries.Remove(delivery);
                        ctx.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show($"Поставщик'{e.Row.Cells["name"].Value}' используется в БД! Удаление данного столбца прервано");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void initializeDgvProviders()
        {
            dgvProviders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_provider",
                Visible = false
            });
            dgvProviders.Columns.Add("name","Название поставщика");
            dgvProviders.Columns.Add("address", "Адрес");
            dgvProviders.Columns.Add(new NumericUpDownColumn()
            {
                Name = "rating",
                HeaderText = "Рейтинг поставщика"
            });


            using (var ctx = new DeliveryContext())
            {
                foreach (var provider in ctx.Providers)
                {
                    var rowIndex = dgvProviders.Rows.Add(provider.id_provider, provider.name, provider.address, provider.rating);
                    dgvProviders.Rows[rowIndex].Tag = provider;
                }
            }
        }

        private void dqvProviders_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvProviders.Rows[e.RowIndex];
            var idProv = (int?)row.Cells["id_provider"].Value;
            if (dgvProviders.IsCurrentRowDirty)
            {
                var cellsWithPotentialErr = new[] { row.Cells["address"], row.Cells["name"]};
                foreach (var cell in cellsWithPotentialErr)
                {
                    if (string.IsNullOrWhiteSpace((string)cell.Value))
                    {
                        row.ErrorText = $"Значчение в столбце'{cell.OwningColumn.HeaderText}' не может быть пустым";
                        e.Cancel = true;
                        break;
                    }
                    if (cell.ColumnIndex == 1)
                    using (var ctx = new DeliveryContext())
                    {
                        foreach (var nameProv in ctx.Providers)
                            if (nameProv.name == (string)cell.Value)
                                if (!(idProv.HasValue) || nameProv.id_provider != idProv)
                                {
                                    row.ErrorText = $"Значчение в столбце'{cell.OwningColumn.HeaderText}' должно быть уникальным";
                                    e.Cancel = true;
                                    break;
                                }
                    }
                }
                if (!e.Cancel)
                {
                    var address = (string)row.Cells["address"].Value;
                    var nameProv = (string)row.Cells["name"].Value;
                    var Rating = int.Parse(row.Cells["rating"].Value.ToString());
                    var q = (Provider)row.Tag;
                    using (var ctx = new DeliveryContext())
                    {
                        if (idProv.HasValue)
                        {
                            ctx.Providers.Attach(q);
                            q.name = nameProv;
                            q.rating = Rating;
                            q.address = address;
                            row.Tag = q;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            var provider = new Provider
                            {
                                address = address,
                                name = nameProv,
                                rating = Rating
                            };
                            ctx.Providers.Add(provider);
                            ctx.SaveChanges();
                            row.Tag = provider;
                            row.Cells["id_provider"].Value = provider.id_provider;
                        }
                    }
                    row.ErrorText = "";
                    foreach (var cell in row.Cells)
                    {
                        ((DataGridViewCell)cell).ErrorText = "";
                    }
                    initializeDgvDelivery();
                }
            }
        }

        private void dgvProviders_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var idProv = (int?)e.Row.Cells["id_provider"].Value;
            if (idProv.HasValue)
            {
                using (var ctx = new DeliveryContext())
                {
                    try
                    {
                        var provider = (Provider)e.Row.Tag;
                        ctx.Providers.Attach(provider);
                        ctx.Providers.Remove(provider);
                        ctx.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show($"Поставщик'{e.Row.Cells["name"].Value}' используется в БД! Удаление данного столбца прервано");
                        e.Cancel = true;
                    }
                    initializeDgvDelivery();
                }
            }
        }
        private void initializeDgvShops()
        {
            dgvShops.Rows.Clear();
            dgvShops.Columns.Clear();
            dgvShops.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_shop",
                Visible = false
            });
            var city_ = new DataGridViewComboBoxColumn
            {
                HeaderText = @"Город",
                Name = "city"
            };
            dgvShops.Columns.Add(city_);
            dgvShops.Columns.Add("address", "Адрес магазина");

            using (var ctx = new DeliveryContext())
            {
                listCity.Clear();
                foreach (var city in ctx.Cities)
                {
                    listCity.Add(city.id_city, city.name);
                }
                city_.DataSource = listCity.Values.ToList();
                foreach (var shop in ctx.Shops)
                {
                    var rowIndex = dgvShops.Rows.Add(shop.id_shop, listCity[shop.id_city], shop.address);
                    dgvShops.Rows[rowIndex].Tag = shop;                    
                }
            }
        }

        private void dgvShops_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvShops.Rows[e.RowIndex];
            var idShop = (int?)row.Cells["id_shop"].Value;
            if (dgvShops.IsCurrentRowDirty)
            {
                var cellsWithPotentialErr = new[] { row.Cells["address"], row.Cells["city"]};
                foreach (var cell in cellsWithPotentialErr)
                {
                    if (string.IsNullOrWhiteSpace((string)cell.Value))
                    {
                        row.ErrorText = $"Значчение в столбце'{cell.OwningColumn.HeaderText}' не может быть пустым";
                        e.Cancel = true;
                        break;
                    }
                    if (cell.ColumnIndex == 2)
                        using (var ctx = new DeliveryContext())
                        {
                            foreach (var shop in ctx.Shops)
                                if (shop.address == (string)cell.Value && (string)listCity[shop.id_city] == (string)row.Cells["city"].Value)
                                    if (!(idShop.HasValue) || (int)row.Cells["id_shop"].Value != (int)shop.id_shop)
                                    {
                                        row.ErrorText = $"Значчение в столбце'{cell.OwningColumn.HeaderText}'должно быть уникальным, так как в одном городе не может быть двух магазинов, находящихся по одному адресу!!!";
                                        e.Cancel = true;
                                        break;
                                    }
                        }
                }
                if (!e.Cancel)
                {
                    var address = (string)row.Cells["address"].Value;
                    var nameCity = (string)row.Cells["city"].Value;
                    var q = (Shop)row.Tag;
                    using (var ctx = new DeliveryContext())
                    {
                        if (idShop.HasValue)
                        {
                            ctx.Shops.Attach(q);
                            foreach (var item in listCity)
                                if (item.Value == nameCity)
                                    q.id_city = item.Key;
                            q.id_shop = (int)row.Cells["id_shop"].Value;
                            q.address = address;
                            row.Tag = q;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            int IdCity = 0;
                            foreach (var item in listCity)
                                if (item.Value == nameCity)
                                    IdCity = item.Key;
                            var shop = new Shop
                            {
                                address = address,
                                id_city = IdCity
                            };
                            ctx.Shops.Add(shop);
                            ctx.SaveChanges();
                            row.Tag = shop;
                            row.Cells["id_shop"].Value = shop.id_shop;
                        }
                    }
                    row.ErrorText = "";
                    foreach (var cell in row.Cells)
                    {
                        ((DataGridViewCell)cell).ErrorText = "";
                    }
                    initializeDgvDelivery();
                }
            }
        }

        private void initializeDgvCity()
        {
            dgvCity.Rows.Clear();
            dgvCity.Columns.Clear();
            dgvCity.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_city",
                Visible = false
            });
            dgvCity.Columns.Add("name", "Город");
            dgvCity.Columns.Add(new NumericUpDownColumn()
            {
                Name = "AvgS",
                HeaderText = "Средняя зараб. плата (ед.изм.: 10 тыс.руб.)"
            });
            dgvCity.Columns.Add(new NumericUpDownColumn()
            {
                Name = "population",
                HeaderText = "Численность начеления (ед.изм.: млн.чел)"
            });
            using (var ctx = new DeliveryContext())
            {
                foreach (var city in ctx.Cities)
                {
                    var rowIndex = dgvCity.Rows.Add(city.id_city, city.name, city.average_salary_level, city.population);
                    dgvCity.Rows[rowIndex].Tag = city;
                }
            }
        }

        private void dgvCity_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvCity.Rows[e.RowIndex];
            var idCity = (int?)row.Cells["id_city"].Value;
            if (dgvCity.IsCurrentRowDirty)
            {
                var cellsWithPotentialErr = new[] { row.Cells["name"] };
                foreach (var cell in cellsWithPotentialErr)
                {
                    if (string.IsNullOrWhiteSpace((string)cell.Value))
                    {
                        row.ErrorText = $"Значчение в столбце'{cell.OwningColumn.HeaderText}' не может быть пустым";
                        e.Cancel = true;
                        break;
                    }
                    using (var ctx = new DeliveryContext())
                    {
                        foreach (var nameCity in ctx.Cities)
                            if (nameCity.name == (string)cell.Value)
                                if (!(idCity.HasValue) || nameCity.id_city != idCity)
                                {
                                    row.ErrorText = $"Значчение в столбце'{cell.OwningColumn.HeaderText}' должно быть уникальным";
                                    e.Cancel = true;
                                    break;
                                }
                    }
                }
                if (!e.Cancel)
                {
                    var name_ = (string)row.Cells["name"].Value;
                    var avgS = (int)row.Cells["AvgS"].Value;
                    var population_ = (int)row.Cells["population"].Value;
                    var q = (City)row.Tag;
                    using (var ctx = new DeliveryContext())
                    {
                        if (idCity.HasValue)
                        {
                            ctx.Cities.Attach(q);
                            q.id_city = (int)row.Cells["id_city"].Value;
                            q.name = name_;
                            q.population = population_;
                            q.average_salary_level = avgS;
                            row.Tag = q;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            var city = new City
                            {
                                name = name_,
                                average_salary_level = avgS,
                                population=population_
                            };
                            ctx.Cities.Add(city);
                            ctx.SaveChanges();
                            row.Tag = city;
                            row.Cells["id_city"].Value = city.id_city;
                        }
                    }
                    row.ErrorText = "";
                    foreach (var cell in row.Cells)
                    {
                        ((DataGridViewCell)cell).ErrorText = "";
                    }
                    initializeDgvShops();
                }
            }
        }

        private void dgvShops_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var idShop = (int?)e.Row.Cells["id_shop"].Value;
            if (idShop.HasValue)
            {
                using (var ctx = new DeliveryContext())
                {
                    try
                    {
                        var shop = (Shop)e.Row.Tag;
                        ctx.Shops.Attach(shop);
                        ctx.Shops.Remove(shop);
                        ctx.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show($"Магазин в городе'{e.Row.Cells["city"].Value}' используется в БД! Удаление данного столбца прервано");
                        e.Cancel = true;
                    }
                    initializeDgvDelivery();
                }
            }
        }

        private void dgvCity_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var idCity = (int?)e.Row.Cells["id_city"].Value;
            if (idCity.HasValue)
            {
                using (var ctx = new DeliveryContext())
                {
                    try
                    {
                        var city = (City)e.Row.Tag;
                        ctx.Cities.Attach(city);
                        ctx.Cities.Remove(city);
                        ctx.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show($"Город'{e.Row.Cells["name"].Value}' используется в БД! Удаление данного столбца прервано");
                        e.Cancel = true;
                    }
                    initializeDgvShops();
                }
            }
        }
    }

}
