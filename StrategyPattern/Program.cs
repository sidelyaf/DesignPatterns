using System;

namespace StrategyPattern
{
    abstract class Character
    {
        IWeaponBehaviour weaponBehaviour;
        public abstract void Fight();
        public void setWeapon(IWeaponBehaviour w) {
            this.weaponBehaviour = w;
        }

        public void UseWeapon(string characterName)
        {
            this.weaponBehaviour.useWeapon(characterName);
        }
    }


    class King : Character
    {
        public override void Fight()
        {
            this.setWeapon(new SwordBehavior());
        }
    }

    class Queen : Character
    {
        public override void Fight()
        {
            this.setWeapon(new BowAndArrowBehavior());
        }
    }

    class Troll : Character
    {
        public override void Fight()
        {
            this.setWeapon(new AxeBehavior());
        }
    }

    class Knight : Character
    {
        public override void Fight()
        {
            this.setWeapon(new KnifeBehavior());
            
        }
    }
    public interface IWeaponBehaviour
    {
        void useWeapon(string characterName);
    }

    public class KnifeBehavior : IWeaponBehaviour
    {
        public void useWeapon(string characterName)
        {
            Console.WriteLine($"{characterName} is cutting with a knife");
        }
    }

    public class SwordBehavior : IWeaponBehaviour
    {
        public void useWeapon(string characterName)
        {
            Console.WriteLine($"{characterName} is swinging a sword");
        }
    }

    public class AxeBehavior : IWeaponBehaviour
    {
        public void useWeapon(string characterName)
        {
            Console.WriteLine($"{characterName} is choping with an axe");
        }
    }

    public class BowAndArrowBehavior : IWeaponBehaviour
    {
        public void useWeapon(string characterName)
        {
            Console.WriteLine($"{characterName} is shooting with a bow and arrow");
        }
    }

    class Context
    {
        private Character character;
        public Context(Character c)
        {
            this.character = c;
        }

        public void Execute(string characterName)
        {
            this.character.Fight();
            this.character.UseWeapon(characterName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // king
            Context context = new Context(new King());
            context.Execute("King ");

            // queen
            context = new Context(new Queen());
            context.Execute("Queen ");

            // troll
            context = new Context(new Troll());
            context.Execute("Troll ");

            // knight
            context = new Context(new Knight());
            context.Execute("Knigt ");

            Console.ReadLine();


            #region Payment example

            //PaymentOperation paymentOperation = null;
            //// Client gelecek olan değere göre runtime'da istediği gibi ödeme tipini seçebilir.
            //string paymentType = "BankTransfer";
            //// If-Else bloklarını ise gerektiğinde bir kaç satır Reflection kodu ile aşabiliriz.
            //// Fakat gerekmedikçe over architectur'ada kaçınılmaması gerekmektedir.
            //// Attığımız taş, ürküttüğümüz kurbağaya değecek mi? Buna karar vererek. :)
            //if (paymentType == "BankTransfer")
            //{
            //    paymentOperation = new PaymentOperation(new BankTransferStrategy());
            //}
            //else if (paymentType == "CreditCard")
            //{
            //    paymentOperation = new PaymentOperation(new CreditCardStrategy());
            //}
            //else if (paymentType == "MailOrder")
            //{
            //    paymentOperation = new PaymentOperation(new MailOrderStrategy());
            //}
            //paymentOperation.MakePayment();
            //Console.ReadLine();
            #endregion
        }
    }

    /// <summary>
    /// Strategy - Tüm ödeme strategy'lerimiz bu interface'den türeyecek.
    /// </summary>
    interface IPayment
    {
        void MakePayment();
    }

    /// <summary>
    /// ConcreteStrategy - Mail order yöntemi ile ödeme strategy'miz.
    /// </summary>
    class MailOrderStrategy : IPayment
    {
        public void MakePayment()
        {
            Console.WriteLine("Mail order yöntemi ile ödeme yapıldı.");
        }
    }

    /// <summary>
    /// ConcreteStrategy - Havale yöntemi ile ödeme strategy'miz.
    /// </summary>
    class BankTransferStrategy : IPayment
    {
        public void MakePayment()
        {
            Console.WriteLine("Havale yöntemi ile ödeme yapıldı.");
        }
    }

    /// <summary>
    /// ConcreteStrategy - Kredi kartı ile ödeme strategy'miz.
    /// </summary>
    class CreditCardStrategy : IPayment
    {
        public void MakePayment()
        {
            Console.WriteLine("Kredi kartı yöntemi ile ödeme yapıldı.");
        }
    }

    // <summary>
    /// Context'imiz. IPayment strategy'mizin içeriğindeki metotları sarmalar.
    /// </summary>
    class PaymentOperation
    {
        private IPayment _odeme;
        public PaymentOperation(IPayment _odeme)
        {
            this._odeme = _odeme;
        }

        public void MakePayment()
        {
            this._odeme.MakePayment();
        }
    }
}
