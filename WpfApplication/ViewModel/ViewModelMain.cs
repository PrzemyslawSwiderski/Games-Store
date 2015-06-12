using kolekcje;
using serializacja;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WpfApplication.Commands;

namespace WpfApplication.ViewModel
{
    public class ViewModelMain : ViewModelBase
    {
        public ViewModelMain()
        {
            kolekcja.WypelnijZakupy();

            UpdateBindingGroup1 = new BindingGroup { Name = "Group1" };
            DodajGraczaCommand = new RelayCommand(DodajGracza);
            UsunGraczaCommand = new RelayCommand(UsunGracza);
            ZapiszGraczaCommand = new RelayCommand(ZapiszGracza);
            SerializujGraczaCommand = new RelayCommand(SerializujGracza);
            DeSerializujGraczaCommand = new RelayCommand(DeSerializujGracza);

            UpdateBindingGroup2 = new BindingGroup { Name = "Group2" };
            DodajGreCommand = new RelayCommand(DodajGre);
            UsunGreCommand = new RelayCommand(UsunGre);
            ZapiszGreCommand = new RelayCommand(ZapiszGre);
            SerializujGreCommand = new RelayCommand(SerializujGre);
            DeSerializujGreCommand = new RelayCommand(DeSerializujGre);

            DodajZakupCommand = new RelayCommand(DodajZakup);
            UsunZakupCommand = new RelayCommand(UsunZakup);
            SerializujZakupyCommand = new RelayCommand(SerializujZakupy);
            DeSerializujzakupyCommand = new RelayCommand(DeSerializujZakupy);
        }

        public Kolekcja kolekcja = new Kolekcja();

        #region Gracze
        public ObservableCollection<Gracz> Gracze
        {
            get
            {
                return new ObservableCollection<Gracz>(kolekcja._gracze);
            }
        }

        void DodajGracza(object parameter)
        {
            SelectedGracz = null;
            var gracz = new Gracz();
            SelectedGracz = gracz;
        }

        void UsunGracza(object parameter)
        {
            if (SelectedIndex != -1)
            {
                kolekcja.UsunGracza(SelectedIndex);
                RaisePropertyChanged("Gracze");
            }
            else
                SelectedGracz = null;
        }

        object _SelectedGracz;
        public object SelectedGracz
        {
            get
            {
                return _SelectedGracz;
            }
            set
            {
                if (_SelectedGracz != value)
                {
                    _SelectedGracz = value;
                    RaisePropertyChanged("SelectedGracz");
                }
            }
        }
        public int SelectedIndex { get; set; }
        BindingGroup _UpdateBindingGroup1;
        public BindingGroup UpdateBindingGroup1
        {
            get
            {
                return _UpdateBindingGroup1;
            }
            set
            {
                if (_UpdateBindingGroup1 != value)
                {
                    _UpdateBindingGroup1 = value;
                    RaisePropertyChanged("UpdateBindingGroup1");
                }
            }
        }
        void ZapiszGracza(object param)
        {
            UpdateBindingGroup1.CommitEdit();
            Gracz gr = SelectedGracz as Gracz;
            if (SelectedIndex == -1)
            {
                kolekcja.DodajGracza(gr);
                RaisePropertyChanged("Gracze");
            }
            SelectedGracz = null;
        }

        void SerializujGracza(object param)
        {
            new XmlConverter().Serializuj(kolekcja._gracze, "gracze");
        }

        void DeSerializujGracza(object param)
        {
            kolekcja._gracze = new XmlConverter().DeSerializuj<List<Gracz>>("gracze");
            RaisePropertyChanged("Gracze");
        }
        public RelayCommand ZapiszGraczaCommand { get; set; }
        public RelayCommand DodajGraczaCommand { get; set; }
        public RelayCommand UsunGraczaCommand { get; set; }
        public RelayCommand SerializujGraczaCommand { get; set; }
        public RelayCommand DeSerializujGraczaCommand { get; set; }
        #endregion
        #region Gry
        public ObservableCollection<Gra> Gry
        {
            get
            {
                return new ObservableCollection<Gra>(kolekcja._gry.Values);
            }
        }

        void DodajGre(object parameter)
        {
            SelectedGra = null;
            Gra gra = new Gra();
            SelectedGra = gra;
        }

        void UsunGre(object parameter)
        {
            if (SelectedIndex2 != -1)
            {
                Gra g = (Gra)SelectedGra;
                kolekcja.UsunGre(g._tytul);
                RaisePropertyChanged("Gry");
            }
            else
                SelectedGra = null;
        }

        object _SelectedGra;
        public object SelectedGra
        {
            get
            {
                return _SelectedGra;
            }
            set
            {
                if (_SelectedGra != value)
                {
                    _SelectedGra = value;
                    RaisePropertyChanged("SelectedGra");
                }
            }
        }
        public int SelectedIndex2 { get; set; }
        BindingGroup _UpdateBindingGroup2;
        public BindingGroup UpdateBindingGroup2
        {
            get
            {
                return _UpdateBindingGroup2;
            }
            set
            {
                if (_UpdateBindingGroup2 != value)
                {
                    _UpdateBindingGroup2 = value;
                    RaisePropertyChanged("UpdateBindingGroup2");
                }
            }
        }
        void ZapiszGre(object param)
        {
            UpdateBindingGroup2.CommitEdit();
            Gra gr = SelectedGra as Gra;
            if (SelectedIndex2 == -1 && gr._liczbaSztuk>0)
            {
                kolekcja.DodajGre(gr);
                RaisePropertyChanged("Gry");
            }
            SelectedGra = null;
        }

        void SerializujGre(object param)
        {
            new XmlConverter().Serializuj(kolekcja._gry.Values.ToList(), "gry");
        }

        void DeSerializujGre(object param)
        {

            List<Gra> list = new XmlConverter().DeSerializuj<List<Gra>>("gry");

            var gry = new Dictionary<string, Gra>(StringComparer.OrdinalIgnoreCase);
            foreach (var g in list)
            {
                gry[g._tytul] = g;
            }
            kolekcja._gry = gry;
            RaisePropertyChanged("Gry");
        }
        public RelayCommand ZapiszGreCommand { get; set; }
        public RelayCommand DodajGreCommand { get; set; }
        public RelayCommand UsunGreCommand { get; set; }
        public RelayCommand SerializujGreCommand { get; set; }
        public RelayCommand DeSerializujGreCommand { get; set; }

        #endregion
        #region Zakupy

        public ObservableCollection<Zakup> Zakupy
        {
            get
            {
                return new ObservableCollection<Zakup>(kolekcja._zakupy);
            }
            set
            {
                Zakupy = value;
            }
        }
        object _SelectedZakup;
        public object SelectedZakup
        {
            get
            {
                return _SelectedZakup;
            }
            set
            {
                if (_SelectedZakup != value)
                {
                    _SelectedZakup = value;
                    RaisePropertyChanged("SelectedZakup");
                }
            }
        }
        public int SelectedIndex3 { get; set; }

        private void DeSerializujZakupy(object obj)
        {
            kolekcja._zakupy = new XmlConverter().DeSerializuj<ObservableCollection<Zakup>>("zakupy");
            RaisePropertyChanged("Zakupy");
        }

        private void SerializujZakupy(object obj)
        {
            new XmlConverter().Serializuj(kolekcja._zakupy, "zakupy");
        }

        private void UsunZakup(object obj)
        {
            if (SelectedIndex3 != -1)
            {
                kolekcja.UsunZakup(SelectedIndex3);
                RaisePropertyChanged("Zakupy");
            }
            else
                SelectedZakup = null;
        }

        private void DodajZakup(object obj)
        {
            Gracz gr = SelectedGracz as Gracz;
            Gra gra = SelectedGra as Gra;
            if (SelectedIndex != -1 && SelectedIndex2 != -1)
            {
                kolekcja.DodajZakup(new Zakup(gr, gra));
                RaisePropertyChanged("Zakupy");
                RaisePropertyChanged("Gry");
            }
            SelectedGracz = null;
            SelectedGra = null;
        }

        public RelayCommand DodajZakupCommand { get; set; }

        public RelayCommand UsunZakupCommand { get; set; }

        public RelayCommand SerializujZakupyCommand { get; set; }

        public RelayCommand DeSerializujzakupyCommand { get; set; }

        #endregion


    }
}
