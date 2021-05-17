namespace DarboLaikoSkaiciavimoSistema
{
    /// <summary>
    /// Vartotojo sąsajos kalbos.
    /// </summary>
    public enum Locale
    { 
        EN,
        LT
    }

    /// <summary>
    /// Naudotojų rolės anglų kalba.
    /// </summary>
    public enum AccessLevelEN
    { 
        Employee = 0,
        Manager = 1,
        Administrator = 2
    }

    /// <summary>
    /// Naudotojų rolės lietuvių kalba.
    /// </summary>
    public enum AccessLevelLT
    {
        Darbuotojas = 0,
        Vadovas = 1,
        Administratorius = 2
    }

    /// <summary>
    /// Vaizdo medžiagos gavimo rėžimai.
    /// </summary>
    public enum VideoMode
    { 
        Stream,
        Recording
    }
}
