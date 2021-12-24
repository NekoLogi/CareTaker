using System;
using System.Collections.Generic;

namespace CareTaker_V2
{
    static class CareTaker
    {
        public static Item SelectedItem;
        static List<Item> ITEMS = new List<Item>();

        public static bool Startup() {
            try {
                ITEMS.Clear();
                if(SaveSystem.Load(ITEMS)) {
                    return true;
                }

                return false;
            } catch(Exception) {
                return false;
            }
        }

        public static Item[] Sort(string product, string category) {
            if(product == null) {
                return DisplayItems();
            } else {
                return SortByName(product, category);
            }
        }

        public static bool CreateItem(Item item) {
            try {
                if(ITEMS.Contains(item)) {
                    return false;
                }
                ITEMS.Add(item);
                SaveSystem.Save(ITEMS);

                return true;
            } catch(Exception) {
                return false;
            }
        }

        public static bool EditItem(Item item) {
            try {
                ITEMS.RemoveAt(ITEMS.IndexOf(SelectedItem));
                ITEMS.Add(item);
                SaveSystem.Save(ITEMS);

                return true;
            } catch(Exception) {
                return false;
            }
        }

        public static bool DeleteItem() {
            try {
                ITEMS.RemoveAt(ITEMS.IndexOf(SelectedItem));
                SaveSystem.Save(ITEMS);

                return true;
            } catch(Exception) {
                return false;
            }
        }

        static Item[] SortByName(string product, string category) {
            var itemsByName = SortName(product);
            var itemsByTags = SortTags(product);
            var result = new List<Item>();

            foreach(var item in itemsByTags) {
                if(!result.Contains(item)) {
                    if(category == "Alles" || category == null || item.CATEGORY == category) {
                        result.Add(item);
                    }
                }
            }
            foreach(var item in itemsByName) {
                if(!result.Contains(item)) {
                    if(category == "Alles" || category == null || item.CATEGORY == category) {
                        result.Add(item);
                    }
                }
            }
            return result.ToArray();
        }

        static Item[] SortName(string name) {
            List<Item> result = new List<Item>();
            foreach(var item in ITEMS) {
                if(item.NAME.ToLower().Contains(name.ToLower())) {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }

        static Item[] SortTags(string name) {
            List<Item> result = new List<Item>();
            foreach(var item in ITEMS) {
                foreach(var tag in item.TAGS) {
                    if(tag.ToLower().Contains(name.ToLower())) {
                        result.Add(item);
                    }
                }
            }
            return result.ToArray();
        }

        public static Item[] SortByPlace(string place) {
            List<Item> result = new List<Item>();
            foreach(var item in ITEMS) {
                if(item.PLACE.ToLower().Contains(place.ToLower())) {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }

        static Item[] DisplayItems() {
            return ITEMS.ToArray();
        }
    }
}
