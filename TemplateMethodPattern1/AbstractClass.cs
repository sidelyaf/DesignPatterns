namespace TemplateMethodPattern
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            ConcreteOperation();
        }

        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();
        public void ConcreteOperation()
        {
            //We also have a concrete operation defined in the abstract class. More about these
            //kinds of methods in a bit...
        }

        public void Hook() { }

    }
}
