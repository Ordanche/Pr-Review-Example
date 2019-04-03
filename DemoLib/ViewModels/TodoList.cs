using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.ViewModels
{
    public class TodoList
    {
        public string ListName;

        public List<Group> Groups;

        public List<Group> GetByPriority
        {
            get { return Groups == null ? null : Groups.OrderByDescending(_ => _.GetPriority).ToList(); }
            set { }
        }

        public List<Item> GetAllItems(ItemEtat etat)
        {
            if (Groups == null)
                return null;

            return Groups.SelectMany(_ => _.Items).ToList().Where(i => i.Etat == etat).ToList();
        }
    }

    public class Group
    {
        public string GroupName;

        public List<Item> Items;

        public List<Item> ItemsATraiter => Items.Where(_ => _.Etat == ItemEtat.aTraiter).ToList();

        public int GetPriority
        {
            get
            {
                var priority = 0;
                if (Items != null && Items.Any())
                {
                    foreach (var item in Items)
                    {
                        switch (item.Etat)
                        {
                            case ItemEtat.indefini:
                            case ItemEtat.termine:
                            case ItemEtat.annule:
                                priority += 0;
                                break;
                            case ItemEtat.aTraiter:
                                priority += 2;
                                break;
                            case ItemEtat.enCours:
                                priority += 1;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }

                return priority;
            }
        }
    }

    public enum ItemEtat
    {
        indefini,
        aTraiter,
        enCours,
        annule = 10,
        termine = 20,
    }

    public class Item
    {
        public static readonly Dictionary<ItemEtat, string> Etats
            = new Dictionary<ItemEtat, string>
            {
                [ItemEtat.indefini] = "--",
                [ItemEtat.aTraiter] = "A traiter",
                [ItemEtat.enCours] = "En cours",
                [ItemEtat.termine] = "Terminé",
                [ItemEtat.annule] = "Annulé",
            };

        public string Nom;

        public ItemEtat Etat;

        public DateTime DateCreation;

        public DateTime? DateFin;

        public DateTime? DateDebut;
    }


    public static class TodoListExtention
    {
        public static Item AddItem(this TodoList List, string Group, string Nom, DateTime? Creation)
        {
            if (Group == null || Group == "")
                return null;

            if (Nom == null || Nom == "")
                return null;

            Group group;
            try
            {
                group = List.Groups.Where(_ => _.GroupName == Group).First();
            }
            catch (Exception e)
            {
                group = new Group();
                group.GroupName = Group;
                List.Groups.Add(group);
            }

            var item = new Item();
            item.Nom = Nom;
            item.DateCreation = DateTime.Now;
            group.Items.Add(item);
            return item;
        }
    }

    public class ItemEtatHelper
    {
        public static void ChangeEtat(Item item, ItemEtat newEtat)
        {
            if (item.Etat == newEtat)
                return;

            if (item.Etat > newEtat)
                throw new Exception();

            if (newEtat == ItemEtat.termine)
                item.DateFin = DateTime.Now;
            else if (newEtat == ItemEtat.enCours)
                item.DateDebut = DateTime.Now;

            item.Etat = newEtat;
        }
    }
}