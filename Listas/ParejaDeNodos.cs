namespace Listas
{
    public class ParejaDeNodos<TKey, TValue>
    {
        public TKey Clave { get; set; }
        public TValue Valor { get; set; }

        public ParejaDeNodos(TKey clave, TValue valor)
        {
            Clave = clave;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"({Clave}, {Valor})";
        }

        public override bool Equals(object obj)
        {
            if (obj is ParejaDeNodos<TKey, TValue> otra)
            {
                return EqualityComparer<TKey>.Default.Equals(this.Clave, otra.Clave);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Clave);
        }
    }
}
