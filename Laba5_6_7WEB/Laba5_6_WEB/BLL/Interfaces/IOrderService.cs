using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        void MakeArea(AreaDTO areaDto);
        void MakeAtraction(AtractionDTO atractionDto);
        HeroDTO MakeHero(HeroDTO heroDto);

        void EditOrder(OrderDTO orderDto);
        void EditArea(AreaDTO areaDto);
        void EditAtraction(AtractionDTO atractionDto);
        void EditHero(HeroDTO heroDto);

        void DeleteOrder(OrderDTO orderDto);
        void DeleteArea(AreaDTO areaDto);
        void DeleteAtraction(AtractionDTO atractionDto);
        void DeleteHero(HeroDTO heroDto);

        OrderDTO GetOrder(int? id);
        AreaDTO GetArea(int? id);
        AtractionDTO GetAtraction(int? id);
        HeroDTO GetHero(int? id);

        IEnumerable<OrderDTO> GetOrders();
        IEnumerable<AreaDTO> GetAreas();
        IEnumerable<AtractionDTO> GetAtractions();
        IEnumerable<HeroDTO> GetHeroes();

        void Dispose();
    }
}
