using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace AvaTabUiTest.MarinosEntities
{
    public class Ship : EntityBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        private int _imo;

        public int Imo
        {
            get => _imo;
            set => this.RaiseAndSetIfChanged(ref _imo, value);
        }

        public Ship(int id, string name, int imo) : base(id)
        {
            _name = name;
            _imo  = imo;
        }

        private static List<Ship> _genShipList()
        {
            return new List<Ship>
                   {
                       new(1, "Vessel1", 001),
                       new(2, "Vessel2", 002),
                       new(3, "Vessel3", 003),
                       new(4, "Vessel4", 004),
                       new(5, "Vessel5", 005),
                   };
        }
        public static List<Ship> GetAll()        => _genShipList().ToList();
        public static Ship?      GetById(int id) => _genShipList().FirstOrDefault(x => x.Id == id);

        public override bool Equals(object? obj)
        {
            return obj is Ship x && x.Id == Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
