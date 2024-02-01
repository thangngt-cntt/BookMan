namespace BookMan;

public class ControllerBase {
    protected void Render<T>(Action<T> action, T model) {
        action?.Invoke(model);
    }

    protected void Render(Action action) {
        action?.Invoke();
    }
}

public class BookController : ControllerBase {
    private readonly BookRepository _repository = new();

    public void List() {
        var model = _repository.Retrieve();
        var view = BookView.Collection;
        Render(view, model);
    }

    public void Single(string param) {
        var id = param.ToParams()["id"].To<int>();
        var model = _repository.Retrieve(id);
        var view = BookView.Single;
        Render(view, model);
    }

    public void AddForm() {
        Render(BookView.Create);
    }

    public void AddNew(string p) {
        var param = p.ToParams();
        var id = param["id"].To<int>();
        var title = param["title"];
        var authors = param["authors"];
        _repository.Create(id, title, authors);
        var model = _repository.Retrieve(id);
        var view = BookView.Single;
        Render(view, model);
    }
}
