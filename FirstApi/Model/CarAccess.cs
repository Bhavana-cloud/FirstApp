namespace FirstApi.Model
{
    public class CarAccess
    {
        private IAccess _Iaccess;
        public CarAccess(IAccess a)
        {
             _Iaccess = a;
        }
    }
    public interface IAccess { }
    public class stearing : IAccess { }
    public class gear : IAccess { }

    public class tier : IAccess { }
    public class seat : IAccess { }
}
