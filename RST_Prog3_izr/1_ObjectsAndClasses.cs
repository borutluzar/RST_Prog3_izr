namespace RST_Prog3_izr
{
    public class TableOld // Glava razreda
    {
        // Jedro razreda

        // Za serijsko številko ne želimo javne spremenljivke, ker nočemo dovoliti njenega spreminjanja izven razreda.
        private int serNum;

        // Ustvarimo element tipa property
        // In to je eksplicitno definirana lastnost
        public int SerialNumber
        {
            get
            {
                return serNum;
            }
            private set //set je dostopen samo znotraj razreda (npr. v funkcijah, drugih lastnostih, ...)
            {
                if (value > 10_000)
                    throw new Exception("Vrednost serijske številke mora biti največ 9999!");
                serNum = value;
            }
        }


        // Za material smo dodali nov enumerator
        public Material Material { get; set; }

        public int numLegs;

        public string type;

        // Samodejno implementirana lastnost
        public string Color { get; set; }

        /// <summary>
        /// Konstruktor za kreiranje mize s serijsko številko
        /// </summary>
        /// <param name="sn">Vrednost serijske številke</param>
        public TableOld(int sn)
        {
            serNum = sn;
            this.Material = Material.Glass;
        }

        /// <summary>
        /// Prazen konstruktor
        /// </summary>
        public TableOld()
        {
            serNum = 1;
        }
    }

    public enum Material
    {
        Wood = 1,
        Stone = 2,
        Glass = 3,
        Plastic = 4
    }
}
