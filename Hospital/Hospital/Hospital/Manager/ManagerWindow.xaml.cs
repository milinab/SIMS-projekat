using ClassDiagram.Model;
using Hospital.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;



namespace Hospital.Manager {
    
    


    public partial class ManagerWindow : Window {





        Room bowser = new Room("Bowser", "Nesto");

        
        Stream stream = File.Open("RoomData.dat", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();

        //formatter.Serialize(bowser, stream);

        


        public ObservableCollection<Room> Rooms
        {
            get;
            set;
        }

        private DelegateCommand<Room> _deleteCommand;
        public DelegateCommand<Room> DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand<Room>(ExecuteDeleteCommand));

        void ExecuteDeleteCommand(Room parameter)
        {
            Rooms.Remove(parameter);
        }

 


        public ManagerWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Rooms = new ObservableCollection<Room>();
            Rooms.Add(new Room { Id = "1", Equipment = "skener" });
            Rooms.Add(new Room { Id = "2", Equipment = "noz" });
            Rooms.Add(new Room { Id = "3", Equipment = "merac" });



        }



        private void EditRoomClick(object sender, RoutedEventArgs e)
        {
        }
        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
           
            Rooms.Add(new Room { Id = TextBox.Text, Equipment = TextBox2.Text });
        }

        private void dataGridRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }

        





        /*      public void GetObjectData(SerializationInfo info, StreamingContext context)
              {
                  info.AddValue("Id", r.Id );
                  info.AddValue("Equipment", r.Equipment);
              }

              public ManagerWindow(SerializationInfo info, StreamingContext context)
              {
                  r.Id = (string)info.GetValue("Id", typeof(string));
                  r.Equipment = (string)info.GetValue("Equimpent", typeof(string));
              }*/
    }
}
