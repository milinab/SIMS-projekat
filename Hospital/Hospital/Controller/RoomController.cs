using ClassDiagram.Model;
using System;
using System.Collections.Generic;

namespace Hospital.Model
{
   public class RoomController
   {
      public Room ReadById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public void Create(Room newRoom)
      {
         // TODO: implement
      }
      
      public void Edit(int id)
      {
         // TODO: implement
      }
      
      public bool Delete(int id)
      {
            //rs.Delete(id);
            return true;
      }
      
      public List<Room> ReadAll()
      {
         // TODO: implement
         return null;
      }
   
      public RoomFileRepository roomFileHandler;
   
      private List<Room> Rooms;
   
   }
}