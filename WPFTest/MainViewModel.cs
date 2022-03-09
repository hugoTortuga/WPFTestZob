using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WPFTest
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private string titre;
        public string Titre
        {
            get { return titre; }
            set
            {
                titre = value;
                OnPropertyChanged();
            }
        }

        private List<Zob> listeZob;
        public List<Zob> ListeZob
        {
            get { return listeZob; }
            set
            {
                listeZob = value;
                OnPropertyChanged();
            }
        }

        private string newZobName;
        public string NewZobName
        {
            get { return newZobName; }
            set
            {
                newZobName = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            
            Titre = "test";
            ListeZob = new List<Zob>()
            {
                new Zob()
                {
                    Name = "Jean-pierre 1",
                    Color = "Rose"
                },
                new Zob()
                {
                    Name = "Jean-pierre 2",
                    Color = "Gris"
                }
            };
        }

        public void CheckBoxClickedCoucou()
        {
            foreach (var zob in ListeZob)
            {
                if (zob.Color == "Vert")
                    zob.Color = "Rouge";
                else 
                    zob.Color = "Vert";
            }
        }

        public void ChangerNomDesZob()
        {
            foreach (var zob in ListeZob)
            {
                if (!string.IsNullOrEmpty(newZobName))
                    zob.Name = newZobName;
            }
        }

        public void NouvelleFenetreClick()
        {
            Messenger.Default.Send("HideValerian");

            var window = new WinZob(ListeZob);
            window.ShowDialog();

            Messenger.Default.Send("ShowValerian");

            var zobViewModel = window.DataContext as ViewModelZob;

            MessageBox.Show(zobViewModel.Bqlskdf);

            //ici la fenetre a été fermé



        }









        #region Magouille on s'en bas les couilles

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}