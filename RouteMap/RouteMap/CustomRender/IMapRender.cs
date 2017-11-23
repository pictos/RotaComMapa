using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteMap.CustomRender
{
    public interface IMapRender
    {
        void SetRenderer(IRendererFunction renderer);

        void CalculoRotaFinalizado();
    }
}
