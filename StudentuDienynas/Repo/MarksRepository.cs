using StudentuDienynas.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Repo
{
    public class MarksRepository
    {
        private List<Mark> Marks { get; set; }
        public MarksRepository()
        {
            Marks = new List<Mark>();
            Marks.Add(new Mark(1, 8, 9, 7));
            Marks.Add(new Mark(2, 6, 4, 10));
            Marks.Add(new Mark(3, 8, 8, 7));
            Marks.Add(new Mark(4, 10, 3, 10));
            Marks.Add(new Mark(5, 6, 4, 6));
            Marks.Add(new Mark(6, 9, 1, 8));
            Marks.Add(new Mark(7, 6, 5, 2));
            Marks.Add(new Mark(8, 8, 3, 3));
            Marks.Add(new Mark(9, 9, 1, 3));
            Marks.Add(new Mark(10, 9, 1, 2));
            Marks.Add(new Mark(11, 10, 3, 6));
            Marks.Add(new Mark(12, 8, 2, 9));
            Marks.Add(new Mark(13, 3, 4, 3));
            Marks.Add(new Mark(14, 3, 9, 4));
            Marks.Add(new Mark(15, 5, 4, 8));
            Marks.Add(new Mark(16, 1, 4, 8));
            Marks.Add(new Mark(17, 2, 7, 8));
            Marks.Add(new Mark(18, 6, 3, 1));
            Marks.Add(new Mark(19, 6, 1, 4));
            Marks.Add(new Mark(20, 3, 5, 8));
        }
        public List<Mark> Retrieve()
        {
            return Marks;
        }
        public Mark Retrieve(int markId)
        {
            return Marks.SingleOrDefault(x => x.Id == markId);
        }

        public void Save(Mark entity)
        {
            Marks.Add(entity);
        }
    }
}
