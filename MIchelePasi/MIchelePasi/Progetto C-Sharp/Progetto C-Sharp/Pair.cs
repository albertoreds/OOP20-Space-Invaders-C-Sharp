

namespace Space
{
    /// <summary>
    /// The Class Pair.
    /// </summary>
    /// @param <X> the generic type </param>
    /// @param <Y> the generic type </param>
    public sealed class Pair<X, Y>
    {

        /// <summary>
        /// The x. </summary>
        private X x;

        /// <summary>
        /// The y. </summary>
        private Y y;
        private int x1;
        private int y1;

        /// <summary>
        /// Instantiates a new pair.
        /// </summary>
        /// <param name="x"> the x </param>
        /// <param name="y"> the y </param>
        public Pair(X x, Y y) : base()
        {

            this.x = x;
            this.y = y;
        }

        public Pair(int x1, int y1)
        {
            this.x1 = x1;
            this.y1 = y1;
        }

        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <returns> the x </returns>
        public X GetX()
        {
            return x;
        }
        public X SetX(X x) => this.x = x;


        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <returns> the y </returns>
        public Y GetY()
        {
            return y;
        }
        public Y SetY(Y y)
        {
            return this.y = y;
        }



        /// <summary>
        /// Hash code.
        /// </summary>
        /// <returns> the int </returns>
        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((x == null) ? 0 : x.GetHashCode());
            result = prime * result + ((y == null) ? 0 : y.GetHashCode());
            return result;

        }

        /// <summary>
        /// Equals.
        /// </summary>
        /// <param name="object"> the object </param>
        /// <returns> true, if successful </returns>
        public override bool Equals(object @object)
        {
            if (this == @object)
            {
                return true;
            }

            if (@object == null)
            {
                return false;
            }

            if (this.GetType() != @object.GetType())
            {
                return false;
            }

            Pair<X, Y> other = (Pair<X, Y>)(@object);
            if (x == null)
            {
                if (other.x != null)
                {
                    return false;
                }
            }
            else if (!x.Equals(other.x))
            {
                return false;
            }
            if (y == null)
            {
                if (other.y != null)
                {
                    return false;
                }
            }
            else if (!y.Equals(other.y))
            {
                return false;

            }
            return true;
        }


        /// <summary>
        /// To string.
        /// </summary>
        /// <returns> the string </returns>
        public override string ToString()
        {
            return "Pair[x=" + x + ", y=" + y + "]";

        }
    }




}