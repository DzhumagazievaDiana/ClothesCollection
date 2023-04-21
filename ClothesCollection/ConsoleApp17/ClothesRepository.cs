using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesCollection
{
    public class ClothesRepository
    {
        private List<Clothes> _clothes;

        public ClothesRepository()
        {
            _clothes = new List<Clothes>();
        }

        public List<Clothes> GetAll()
        {
            return _clothes;
        }

        public Clothes GetById(int id)
        {
            return _clothes.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Clothes clothes)
        {
            clothes.Id = _clothes.Count + 1;
            _clothes.Add(clothes);
        }

        public void Delete(int id)
        {
            var clothes = GetById(id);
            if (clothes != null)
            {
                _clothes.Remove(clothes);
            }
        }

        public void Update(Clothes clothes)
        {
            var existingClothes = GetById(clothes.Id);
            if (existingClothes != null)
            {
                existingClothes.Brand = clothes.Brand;
                existingClothes.Style = clothes.Style;
                existingClothes.Price = clothes.Price;
            }
        }

        public List<Clothes> Find(Func<Clothes, bool> predicate)
        {
            return _clothes.Where(predicate).ToList();
        }
    }
}
    

