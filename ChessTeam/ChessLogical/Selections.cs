using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using ChessTeam.ChessLogical.Tableaux;
using ChessTeam.ChessLogical.Types;
using static ChessTeam.ChessLogical.Tableaux.Tableaux;

namespace ChessTeam.ChessLogical;

public class Selections : INotifyPropertyChanged
{

    public void Disable()
    {
        var p = this.GetType();
        foreach(var property in p.GetProperties())
        {
            
            Debug.Write(property.Name);
            
        }
    }
    private CarreauElement _A1 = new(Carreau.A1);
    public CarreauElement A1
    {
        get => _A1;
        set
        {
        _A1 = value;
        PropertyChanged?.Invoke(this,new(nameof(A1)));
        }
    }
    private CarreauElement _A2 = new(Carreau.A2);
    public CarreauElement A2
    {
        get => _A2;
        set
        {
        _A2 = value;
        PropertyChanged?.Invoke(this,new(nameof(A2)));
        }
    }
    private CarreauElement _A3 = new(Carreau.A3);
    public CarreauElement A3
    {
        get => _A3;
        set
        {
        _A3 = value;
        PropertyChanged?.Invoke(this,new(nameof(A3)));
        }
    }
    private CarreauElement _A4 = new(Carreau.A4);
    public CarreauElement A4
    {
        get => _A4;
        set
        {
        _A4 = value;
        PropertyChanged?.Invoke(this,new(nameof(A4)));
        }
    }
    private CarreauElement _A5 = new(Carreau.A5);
    public CarreauElement A5
    {
        get => _A5;
        set
        {
        _A5 = value;
        PropertyChanged?.Invoke(this,new(nameof(A5)));
        }
    }
    private CarreauElement _A6 = new(Carreau.A6);
    public CarreauElement A6
    {
        get => _A6;
        set
        {
        _A6 = value;
        PropertyChanged?.Invoke(this,new(nameof(A6)));
        }
    }
    private CarreauElement _A7 = new(Carreau.A7);
    public CarreauElement A7
    {
        get => _A7;
        set
        {
        _A7 = value;
        PropertyChanged?.Invoke(this,new(nameof(A7)));
        }
    }
    private CarreauElement _A8 = new(Carreau.A8);
    public CarreauElement A8
    {
        get => _A8;
        set
        {
        _A8 = value;
        PropertyChanged?.Invoke(this,new(nameof(A8)));
        }
    }
    private CarreauElement _B1 = new(Carreau.B1);
    public CarreauElement B1
    {
        get => _B1;
        set
        {
        _B1 = value;
        PropertyChanged?.Invoke(this,new(nameof(B1)));
        }
    }
    private CarreauElement _B2 = new(Carreau.B2);
    public CarreauElement B2
    {
        get => _B2;
        set
        {
        _B2 = value;
        PropertyChanged?.Invoke(this,new(nameof(B2)));
        }
    }
    private CarreauElement _B3 = new(Carreau.B3);
    public CarreauElement B3
    {
        get => _B3;
        set
        {
        _B3 = value;
        PropertyChanged?.Invoke(this,new(nameof(B3)));
        }
    }
    private CarreauElement _B4 = new(Carreau.B4);
    public CarreauElement B4
    {
        get => _B4;
        set
        {
        _B4 = value;
        PropertyChanged?.Invoke(this,new(nameof(B4)));
        }
    }
    private CarreauElement _B5 = new(Carreau.B5);
    public CarreauElement B5
    {
        get => _B5;
        set
        {
        _B5 = value;
        PropertyChanged?.Invoke(this,new(nameof(B5)));
        }
    }
    private CarreauElement _B6 = new(Carreau.B6);
    public CarreauElement B6
    {
        get => _B6;
        set
        {
        _B6 = value;
        PropertyChanged?.Invoke(this,new(nameof(B6)));
        }
    }
    private CarreauElement _B7 = new(Carreau.B7);
    public CarreauElement B7
    {
        get => _B7;
        set
        {
        _B7 = value;
        PropertyChanged?.Invoke(this,new(nameof(B7)));
        }
    }
    private CarreauElement _B8 = new(Carreau.B8);
    public CarreauElement B8
    {
        get => _B8;
        set
        {
        _B8 = value;
        PropertyChanged?.Invoke(this,new(nameof(B8)));
        }
    }
    private CarreauElement _C1 = new(Carreau.C1);
    public CarreauElement C1
    {
        get => _C1;
        set
        {
        _C1 = value;
        PropertyChanged?.Invoke(this,new(nameof(C1)));
        }
    }
    private CarreauElement _C2 = new(Carreau.C2);
    public CarreauElement C2
    {
        get => _C2;
        set
        {
        _C2 = value;
        PropertyChanged?.Invoke(this,new(nameof(C2)));
        }
    }
    private CarreauElement _C3 = new(Carreau.C3);
    public CarreauElement C3
    {
        get => _C3;
        set
        {
        _C3 = value;
        PropertyChanged?.Invoke(this,new(nameof(C3)));
        }
    }
    private CarreauElement _C4 = new(Carreau.C4);
    public CarreauElement C4
    {
        get => _C4;
        set
        {
        _C4 = value;
        PropertyChanged?.Invoke(this,new(nameof(C4)));
        }
    }
    private CarreauElement _C5 = new(Carreau.C5);
    public CarreauElement C5
    {
        get => _C5;
        set
        {
        _C5 = value;
        PropertyChanged?.Invoke(this,new(nameof(C5)));
        }
    }
    private CarreauElement _C6 = new(Carreau.C6);
    public CarreauElement C6
    {
        get => _C6;
        set
        {
        _C6 = value;
        PropertyChanged?.Invoke(this,new(nameof(C6)));
        }
    }
    private CarreauElement _C7 = new(Carreau.C7);
    public CarreauElement C7
    {
        get => _C7;
        set
        {
        _C7 = value;
        PropertyChanged?.Invoke(this,new(nameof(C7)));
        }
    }
    private CarreauElement _C8 = new(Carreau.C8);
    public CarreauElement C8
    {
        get => _C8;
        set
        {
        _C8 = value;
        PropertyChanged?.Invoke(this,new(nameof(C8)));
        }
    }
    private CarreauElement _D1 = new(Carreau.D1);
    public CarreauElement D1
    {
        get => _D1;
        set
        {
        _D1 = value;
        PropertyChanged?.Invoke(this,new(nameof(D1)));
        }
    }
    private CarreauElement _D2 = new(Carreau.D2);
    public CarreauElement D2
    {
        get => _D2;
        set
        {
        _D2 = value;
        PropertyChanged?.Invoke(this,new(nameof(D2)));
        }
    }
    private CarreauElement _D3 = new(Carreau.D3);
    public CarreauElement D3
    {
        get => _D3;
        set
        {
        _D3 = value;
        PropertyChanged?.Invoke(this,new(nameof(D3)));
        }
    }
    private CarreauElement _D4 = new(Carreau.D4);
    public CarreauElement D4
    {
        get => _D4;
        set
        {
        _D4 = value;
        PropertyChanged?.Invoke(this,new(nameof(D4)));
        }
    }
    private CarreauElement _D5 = new(Carreau.D5);
    public CarreauElement D5
    {
        get => _D5;
        set
        {
        _D5 = value;
        PropertyChanged?.Invoke(this,new(nameof(D5)));
        }
    }
    private CarreauElement _D6 = new(Carreau.D6);
    public CarreauElement D6
    {
        get => _D6;
        set
        {
        _D6 = value;
        PropertyChanged?.Invoke(this,new(nameof(D6)));
        }
    }
    private CarreauElement _D7 = new(Carreau.D7);
    public CarreauElement D7
    {
        get => _D7;
        set
        {
        _D7 = value;
        PropertyChanged?.Invoke(this,new(nameof(D7)));
        }
    }
    private CarreauElement _D8 = new(Carreau.D8);
    public CarreauElement D8
    {
        get => _D8;
        set
        {
        _D8 = value;
        PropertyChanged?.Invoke(this,new(nameof(D8)));
        }
    }
    private CarreauElement _E1 = new(Carreau.E1);
    public CarreauElement E1
    {
        get => _E1;
        set
        {
        _E1 = value;
        PropertyChanged?.Invoke(this,new(nameof(E1)));
        }
    }
    private CarreauElement _E2 = new(Carreau.E2);
    public CarreauElement E2
    {
        get => _E2;
        set
        {
        _E2 = value;
        PropertyChanged?.Invoke(this,new(nameof(E2)));
        }
    }
    private CarreauElement _E3 = new(Carreau.E3);
    public CarreauElement E3
    {
        get => _E3;
        set
        {
        _E3 = value;
        PropertyChanged?.Invoke(this,new(nameof(E3)));
        }
    }
    private CarreauElement _E4 = new(Carreau.E4);
    public CarreauElement E4
    {
        get => _E4;
        set
        {
        _E4 = value;
        PropertyChanged?.Invoke(this,new(nameof(E4)));
        }
    }
    private CarreauElement _E5 = new(Carreau.E5);
    public CarreauElement E5
    {
        get => _E5;
        set
        {
        _E5 = value;
        PropertyChanged?.Invoke(this,new(nameof(E5)));
        }
    }
    private CarreauElement _E6 = new(Carreau.E6);
    public CarreauElement E6
    {
        get => _E6;
        set
        {
        _E6 = value;
        PropertyChanged?.Invoke(this,new(nameof(E6)));
        }
    }
    private CarreauElement _E7 = new(Carreau.E7);
    public CarreauElement E7
    {
        get => _E7;
        set
        {
        _E7 = value;
        PropertyChanged?.Invoke(this,new(nameof(E7)));
        }
    }
    private CarreauElement _E8 = new(Carreau.E8);
    public CarreauElement E8
    {
        get => _E8;
        set
        {
        _E8 = value;
        PropertyChanged?.Invoke(this,new(nameof(E8)));
        }
    }
    private CarreauElement _F1 = new(Carreau.F1);
    public CarreauElement F1
    {
        get => _F1;
        set
        {
        _F1 = value;
        PropertyChanged?.Invoke(this,new(nameof(F1)));
        }
    }
    private CarreauElement _F2 = new(Carreau.F2);
    public CarreauElement F2
    {
        get => _F2;
        set
        {
        _F2 = value;
        PropertyChanged?.Invoke(this,new(nameof(F2)));
        }
    }
    private CarreauElement _F3 = new(Carreau.F3);
    public CarreauElement F3
    {
        get => _F3;
        set
        {
        _F3 = value;
        PropertyChanged?.Invoke(this,new(nameof(F3)));
        }
    }
    private CarreauElement _F4 = new(Carreau.F4);
    public CarreauElement F4
    {
        get => _F4;
        set
        {
        _F4 = value;
        PropertyChanged?.Invoke(this,new(nameof(F4)));
        }
    }
    private CarreauElement _F5 = new(Carreau.F5);
    public CarreauElement F5
    {
        get => _F5;
        set
        {
        _F5 = value;
        PropertyChanged?.Invoke(this,new(nameof(F5)));
        }
    }
    private CarreauElement _F6 = new(Carreau.F6);
    public CarreauElement F6
    {
        get => _F6;
        set
        {
        _F6 = value;
        PropertyChanged?.Invoke(this,new(nameof(F6)));
        }
    }
    private CarreauElement _F7 = new(Carreau.F7);
    public CarreauElement F7
    {
        get => _F7;
        set
        {
        _F7 = value;
        PropertyChanged?.Invoke(this,new(nameof(F7)));
        }
    }
    private CarreauElement _F8 = new(Carreau.F8);
    public CarreauElement F8
    {
        get => _F8;
        set
        {
        _F8 = value;
        PropertyChanged?.Invoke(this,new(nameof(F8)));
        }
    }
    private CarreauElement _G1 = new(Carreau.G1);
    public CarreauElement G1
    {
        get => _G1;
        set
        {
        _G1 = value;
        PropertyChanged?.Invoke(this,new(nameof(G1)));
        }
    }
    private CarreauElement _G2 = new(Carreau.G2);
    public CarreauElement G2
    {
        get => _G2;
        set
        {
        _G2 = value;
        PropertyChanged?.Invoke(this,new(nameof(G2)));
        }
    }
    private CarreauElement _G3 = new(Carreau.G3);
    public CarreauElement G3
    {
        get => _G3;
        set
        {
        _G3 = value;
        PropertyChanged?.Invoke(this,new(nameof(G3)));
        }
    }
    private CarreauElement _G4 = new(Carreau.G4);
    public CarreauElement G4
    {
        get => _G4;
        set
        {
        _G4 = value;
        PropertyChanged?.Invoke(this,new(nameof(G4)));
        }
    }
    private CarreauElement _G5 = new(Carreau.G5);
    public CarreauElement G5
    {
        get => _G5;
        set
        {
        _G5 = value;
        PropertyChanged?.Invoke(this,new(nameof(G5)));
        }
    }
    private CarreauElement _G6 = new(Carreau.G6);
    public CarreauElement G6
    {
        get => _G6;
        set
        {
        _G6 = value;
        PropertyChanged?.Invoke(this,new(nameof(G6)));
        }
    }
    private CarreauElement _G7 = new(Carreau.G7);
    public CarreauElement G7
    {
        get => _G7;
        set
        {
        _G7 = value;
        PropertyChanged?.Invoke(this,new(nameof(G7)));
        }
    }
    private CarreauElement _G8 = new(Carreau.G8);
    public CarreauElement G8
    {
        get => _G8;
        set
        {
        _G8 = value;
        PropertyChanged?.Invoke(this,new(nameof(G8)));
        }
    }
    private CarreauElement _H1 = new(Carreau.H1);
    public CarreauElement H1
    {
        get => _H1;
        set
        {
        _H1 = value;
        PropertyChanged?.Invoke(this,new(nameof(H1)));
        }
    }
    private CarreauElement _H2 = new(Carreau.H2);
    public CarreauElement H2
    {
        get => _H2;
        set
        {
        _H2 = value;
        PropertyChanged?.Invoke(this,new(nameof(H2)));
        }
    }
    private CarreauElement _H3 = new(Carreau.H3);
    public CarreauElement H3
    {
        get => _H3;
        set
        {
        _H3 = value;
        PropertyChanged?.Invoke(this,new(nameof(H3)));
        }
    }
    private CarreauElement _H4 = new(Carreau.H4);
    public CarreauElement H4
    {
        get => _H4;
        set
        {
        _H4 = value;
        PropertyChanged?.Invoke(this,new(nameof(H4)));
        }
    }
    private CarreauElement _H5 = new(Carreau.H5);
    public CarreauElement H5
    {
        get => _H5;
        set
        {
        _H5 = value;
        PropertyChanged?.Invoke(this,new(nameof(H5)));
        }
    }
    private CarreauElement _H6 = new(Carreau.H6);
    public CarreauElement H6
    {
        get => _H6;
        set
        {
        _H6 = value;
        PropertyChanged?.Invoke(this,new(nameof(H6)));
        }
    }
    private CarreauElement _H7 = new(Carreau.H7);
    public CarreauElement H7
    {
        get => _H7;
        set
        {
        _H7 = value;
        PropertyChanged?.Invoke(this,new(nameof(H7)));
        }
    }
    private CarreauElement _H8 = new(Carreau.H8);
    public CarreauElement H8
    {
        get => _H8;
        set
        {
        _H8 = value;
        PropertyChanged?.Invoke(this,new(nameof(H8)));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}

public class CarreauElement:INotifyPropertyChanged
{
    private bool _IsActived = true;
    public bool IsActived
    {
        get => _IsActived;
        set
        {
            _IsActived = value;
            PropertyChanged?.Invoke(this, new(nameof(IsActived)));
        }
    }
    public Chess? LinkChess { get
        {
            var r = Tableaux.Tableaux.GetPosition(carreau: linkCarreau);
            try
            {
                return Conservateur.Initialisateur.GetInstanceChess(r);
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
    public readonly Carreau linkCarreau;

    public CarreauElement(Carreau carreau)
    {
        linkCarreau = carreau;
        Conservateur.Initialisateur.AddCarreau(carreau, GetCarreauElementInstance);
    }
    private CarreauElement GetCarreauElementInstance()
    {
        return this;
    }

    public string ChessObject
    {
        get => ChessSpace(LinkChess?.Type,LinkChess?.Camp);

        set
        {
            PropertyChanged?.Invoke(this, new(nameof(ChessObject)));
        }
    }
    
    private string ChessSpace(TypeChess? typeChess,TypeCamp? camp)
    {
        switch(typeChess,camp)
        {
            case (TypeChess.Pion, TypeCamp.W):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Cavalier, TypeCamp.W):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Tour, TypeCamp.W):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Roi, TypeCamp.W):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Reine, TypeCamp.W):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Fou, TypeCamp.W):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Pion, TypeCamp.B):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Cavalier, TypeCamp.B):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Tour, TypeCamp.B):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Roi, TypeCamp.B):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Reine, TypeCamp.B):
                return $"/{typeChess}{camp}.png";
            case (TypeChess.Fou, TypeCamp.B):
                return $"/{typeChess}{camp}.png";
            default :
                return "";
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
}