using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DemoLib.Model;

namespace DemoLib.Dal
{
    public class DC : DataContext
    {
        private DbConnection _connection;

        public DC(string sCon)
        {
            _connection = new SqlConnection(sCon);
        }

        public Item GetItem(Guid itemId)
        {
            var rq = "SELECT * FROM Item WHERE Id = " + itemId + ";";
            return _connection.QueryFirstOrDefault<Item>(rq);
        }

        public IList<Item> GetItems(string name)
        {
            var rq = "SELECT Id, Name, Group, State, Creation, Complete " +
                     "FROM Item " +
                     "JOIN Group ON Group.Id = Item.IdGroup " +
                     "WHERE Group = '{0}';";

            return _connection.Query<Item>(string.Format(rq, name)).ToList();
        }

        public void Save(Item item)
        {
            if (item.Id == null)
            {
                item.Id = Insert(item);
            }
            else
            {
                Update(item);
            }
        }

        private Guid Insert(Item item)
        {
            var id = new Guid();
            var rq = "INSERT INTO Item (Id, Name, State, Creation, Complete) "+
                "VALUES(@Id, @Name, @State, @Creation, @Complete);";
            _connection.Execute(rq, item);
            return id;
        }

        // TODO
        private void Update(Item item)
        {

        }
    }
}