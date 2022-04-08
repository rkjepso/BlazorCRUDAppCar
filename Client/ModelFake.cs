namespace BlazorCRUDApp.Client;

static public class ModelFake
{
    public static List<Car> Lst = new ();
    public static Car Add(Car car)
    {
        if (Lst.Any())
            car.Id = Lst.Select (x => x.Id).Max () + 1;
        else
            car.Id = 1;
        Lst.Add(car);
        return car;
    }

    public static bool Update(Car car)
    {
        int id =  Lst.FindIndex(x => x.Id == car.Id);
        Lst[id] = car;
        return true;
    }

    

    public static bool DeleteById(int Id)
    {
        Lst.RemoveAll(x => x.Id == Id);
        return true;
    }
        
}

