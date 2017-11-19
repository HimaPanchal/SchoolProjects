using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Elements
    {
        private Dictionary<string, ElementValue> _dictionary = new Dictionary<string, ElementValue>();
        public Dictionary<string, ElementValue> ElementDictionary { get { return _dictionary; } }

        public Elements()
        {
            _dictionary.Add("H", new ElementValue(1.0079, "Hydrogen", 1));
            _dictionary.Add("He", new ElementValue(4.0026, "Helium", 2));
            _dictionary.Add("Li", new ElementValue(6.941, "Lithium", 3));
            _dictionary.Add("Be", new ElementValue(9.0122, "Beryllium", 4));
            _dictionary.Add("B", new ElementValue(10.811, "Boron", 5));
            _dictionary.Add("C", new ElementValue(12.0107, "Carbon", 6));
            _dictionary.Add("N", new ElementValue(14.0067, "Nitrogen", 7));
            _dictionary.Add("O", new ElementValue(15.9994, "Oxygen", 8));
            _dictionary.Add("F", new ElementValue(18.9984, "Fluorine", 9));
            _dictionary.Add("Ne", new ElementValue(20.1797, "Neon", 10));

            _dictionary.Add("Na", new ElementValue(22.9897, "Sodium", 11));
            _dictionary.Add("Mg", new ElementValue(24.305, "Magnesium", 12));
            _dictionary.Add("Al", new ElementValue(26.9815, "Aluminum", 13));
            _dictionary.Add("Si", new ElementValue(28.0855, "Silicon", 14));
            _dictionary.Add("P", new ElementValue(30.9738, "Phosphorus", 15));
            _dictionary.Add("S", new ElementValue(32.065, "Sulphur", 16));
            _dictionary.Add("Cl", new ElementValue(35.43, "Chlorine", 17));
            _dictionary.Add("Ar", new ElementValue(39.948, "Argon", 18));
            _dictionary.Add("K", new ElementValue(39.0983, "Potassium", 19));
            _dictionary.Add("Ca", new ElementValue(40.078, "Calcium", 20));

            _dictionary.Add("Sc", new ElementValue(44.9559, "Scandium", 21));
            _dictionary.Add("Ti", new ElementValue(47.867, "Titanium", 22));
            _dictionary.Add("V", new ElementValue(50.9415, "Vanadium", 23));
            _dictionary.Add("Cr", new ElementValue(51.9961, "Chromium", 24));
            _dictionary.Add("Mn", new ElementValue(54.938, "Manganese", 25));
            _dictionary.Add("Fe", new ElementValue(55.845, "Iron", 26));
            _dictionary.Add("Co", new ElementValue(58.9332, "Cobalt", 27));
            _dictionary.Add("Ni", new ElementValue(58.6934, "Nickel", 28));
            _dictionary.Add("Cu", new ElementValue(63.546, "Copper", 29));
            _dictionary.Add("Zn", new ElementValue(65.39, "Zinc", 30));

            _dictionary.Add("Ga", new ElementValue(69.723, "Gallium", 31));
            _dictionary.Add("Ge", new ElementValue(72.64, "Germanium", 32));
            _dictionary.Add("As", new ElementValue(74.9216, "Arsenic", 33));
            _dictionary.Add("Se", new ElementValue(78.96, "Selenium", 34));
            _dictionary.Add("Br", new ElementValue(79.904, "Bromine", 35));
            _dictionary.Add("Kr", new ElementValue(83.8, "Krypton", 36));
            _dictionary.Add("Rb", new ElementValue(85.4678, "Rubidium", 37));
            _dictionary.Add("Sr", new ElementValue(87.62, "Strontium", 38));
            _dictionary.Add("Y", new ElementValue(88.9059, "Yttrium", 39));
            _dictionary.Add("Zr", new ElementValue(91.224, "Zirconium", 40));

            _dictionary.Add("Nb", new ElementValue(92.9064, "Niobium", 41));
            _dictionary.Add("Mo", new ElementValue(95.94, "Molybdenum", 42));
            _dictionary.Add("Tc", new ElementValue(98, "Technetium", 43));
            _dictionary.Add("Ru", new ElementValue(101.07, "Ruthenium", 44));
            _dictionary.Add("Rh", new ElementValue(102.9055, "Rhodium", 45));
            _dictionary.Add("Pd", new ElementValue(106.42, "Palladium", 46));
            _dictionary.Add("Ag", new ElementValue(107.8682, "Silver", 47));
            _dictionary.Add("Cd", new ElementValue(112.411, "Cadmium", 48));
            _dictionary.Add("In", new ElementValue(114.818, "Indium", 49));
            _dictionary.Add("Sn", new ElementValue(118.71, "Tin", 50));

            _dictionary.Add("Sb", new ElementValue(121.76, "Antimony", 51));
            _dictionary.Add("Te", new ElementValue(127.6, "Tellurium", 52));
            _dictionary.Add("I", new ElementValue(126.9045, "Iodine", 53));
            _dictionary.Add("Xe", new ElementValue(131.293, "Xenon", 54));
            _dictionary.Add("Cs", new ElementValue(132.9055, "Cesium", 55));
            _dictionary.Add("Ba", new ElementValue(137.327, "Barium", 56));
            _dictionary.Add("La", new ElementValue(138.9055, "Lanthanum", 57));
            _dictionary.Add("Ce", new ElementValue(140.116, "Cerium", 58));
            _dictionary.Add("Pr", new ElementValue(140.9077, "Praseodymium", 59));
            _dictionary.Add("Nd", new ElementValue(144.24, "Neodymium", 60));

            _dictionary.Add("Pm", new ElementValue(145, "Promethium", 61));
            _dictionary.Add("Sm", new ElementValue(150.36, "Samarium", 62));
            _dictionary.Add("Eu", new ElementValue(151.964, "Europium", 63));
            _dictionary.Add("Gd", new ElementValue(157.25, "Gadolinium", 64));
            _dictionary.Add("Tb", new ElementValue(158.9253, "Terbium", 65));
            _dictionary.Add("Dy", new ElementValue(162.5, "Dysprosium", 66));
            _dictionary.Add("Ho", new ElementValue(164.9303, "Holmium", 67));
            _dictionary.Add("Er", new ElementValue(167.259, "Erbium", 68));
            _dictionary.Add("Tm", new ElementValue(168.9342, "Thulium", 69));
            _dictionary.Add("Yb", new ElementValue(173.04, "Ytterbium", 70));

            _dictionary.Add("Lu", new ElementValue(174.967, "Lutetium", 71));
            _dictionary.Add("Hf", new ElementValue(178.49, "Hafnium", 72));
            _dictionary.Add("Ta", new ElementValue(180.9479, "Tantalum", 73));
            _dictionary.Add("W", new ElementValue(183.84, "Tungsten", 74));
            _dictionary.Add("Re", new ElementValue(186.207, "Rhenium", 75));
            _dictionary.Add("Os", new ElementValue(190.23, "Osmium", 76));
            _dictionary.Add("Ir", new ElementValue(192.217, "Iridium", 77));
            _dictionary.Add("Pt", new ElementValue(195.078, "Platinum", 78));
            _dictionary.Add("Au", new ElementValue(196.9665, "Gold", 79));
            _dictionary.Add("Hg", new ElementValue(200.59, "Mercury", 80));

            _dictionary.Add("Tl", new ElementValue(204.3833, "Thallium", 81));
            _dictionary.Add("Pb", new ElementValue(207.2, "Lead", 82));
            _dictionary.Add("Bi", new ElementValue(208.9804, "Bismuth", 83));
            _dictionary.Add("Po", new ElementValue(209, "Polonium", 84));
            _dictionary.Add("At", new ElementValue(210, "Astatine", 85));
            _dictionary.Add("Rn", new ElementValue(222, "Radon", 86));
            _dictionary.Add("Fr", new ElementValue(223, "Francium", 87));
            _dictionary.Add("Ra", new ElementValue(226, "Radium", 88));
            _dictionary.Add("Ac", new ElementValue(227, "Actinium", 89));
            _dictionary.Add("Th", new ElementValue(232.0381, "Thorium", 90));

            _dictionary.Add("Pa", new ElementValue(231.0359, "Protactinium", 91));
            _dictionary.Add("U", new ElementValue(238.0289, "Uranium", 92));
            _dictionary.Add("Np", new ElementValue(237, "Neptunium", 93));
            _dictionary.Add("Pu", new ElementValue(244, "Plutonium", 94));
            _dictionary.Add("Am", new ElementValue(243, "Americium", 95));
            _dictionary.Add("Cm", new ElementValue(247, "Curium", 96));
            _dictionary.Add("Bk", new ElementValue(247, "Berkelium", 97));
            _dictionary.Add("Cf", new ElementValue(251, "Californium", 98));
            _dictionary.Add("Es", new ElementValue(252, "Einsteinium", 99));
        }
    }

    public class ElementValue
    {
        private double _atomicMass;
        private string _name;
        private int _atomicNumber;

        public double AtomicMass { get { return _atomicMass; } }

        public string Name { get { return _name; } }

        public int AtomicNumber { get { return _atomicNumber; } }

        public ElementValue(double atomicMass, string name, int atomicNumber)
        {
            _atomicMass = atomicMass;
            _name = name;
            _atomicNumber = atomicNumber;
        }
    }
}
