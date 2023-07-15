using QuestionsWeb.Domain.Entities;

namespace QuestionsWeb.Data;

public static class TestData
{
    static TestData()
    {
        var categories = new BlogCategory[]
        {
            new() { Id = 1, Name = "College", },
            new() { Id = 2, Name = "Gym", },
            new() { Id = 3, Name = "High School", },
            new() { Id = 4, Name = "Primary", },
            new() { Id = 5, Name = "School", },
            new() { Id = 6, Name = "University", },
        };
        Categories = categories;

        var rnd = new Random(10);

        var authors = Enumerable
            .Range(1, 5)
            .Select(id => new Author
            {
                Id = id,
                Name = $"Author-{id}",
            })
            .ToArray();
        Authors = authors;

        Posts = Enumerable
            .Range(1, 50)
            .Select(id => new BlogPost
            {
                Id = id,
                Date = DateTimeOffset.Now.AddDays(rnd.Next(5, 150)),
                Title = $"Blog post {id} title",
                AbstractText = $"Blog post {id} abstract text",
                PreviewImage = "/img/blog-list/1.png",
                MainImage = "/img/blog/blog-single/images.png",
                AuthorId = authors[rnd.Next(authors.Length)].Id,
                CategoryId = categories[rnd.Next(categories.Length)].Id,
                Content = """
                          <h4 class="text-18 fw-500">What makes a good brand book?</h4>
                          <p class="mt-30">Sed viverra ipsum nunc aliquet bibendum enim facilisis gravida. Diam phasellus vestibulum lorem sed risus ultricies. Magna sit amet purus gravida quis blandit. Arcu cursus vitae congue mauris. Nunc mattis enim ut tellus elementum sagittis vitae et leo. Semper risus in hendrerit gravida rutrum quisque non. At urna condimentum mattis pellentesque id nibh tortor. A erat nam at lectus urna duis convallis convallis tellus. Sit amet mauris commodo quis imperdiet massa. Vitae congue eu consequat ac felis.</p>

                          <ul class="ul-list y-gap-10 mt-30">
                              <li>Sed viverra ipsum nunc aliquet bibendum enim facilisis gravida.</li>
                              <li>At urna condimentum mattis pellentesque id nibh. Laoreet non curabitur</li>
                              <li>Magna etiam tempor orci eu lobortis elementum.</li>
                              <li>Bibendum est ultricies integer quis. Semper eget duis at tellus.</li>
                          </ul>

                          <!-- <div class="py-25 pl-90 lg:pl-80 md:px-32 border-left-2-accent text-center mt-30 lg:mt-40">
                            <div class="">
                              <i class="icon icon-quote"></i>
                            </div>

                            <div class="text-dark-1 fw-500 italic text-2xl lh-17">
                              “Sed viverra ipsum nunc aliquet bibendum enim facilisis gravida. Diam phasellus vestibulum lorem sed risus ultricies. Magna sit amet purus gravida quis blandit. Arcu cursus vitae congue mauris.“
                            </div>
                          </div> -->

                          <p class="mt-30">
                              Donec purus posuere nullam lacus aliquam egestas arcu. A egestas a, tellus massa, ornare vulputate. Erat enim eget laoreet ullamcorper lectus aliquet nullam tempus id. Dignissim convallis quam aliquam rhoncus, lectus nullam viverra. Bibendum dignissim tortor, phasellus pellentesque commodo, turpis vel eu. Donec consectetur ipsum nibh lobortis elementum mus velit tincidunt elementum. Ridiculus eu convallis eu mattis iaculis et, in dolor. Sem libero, tortor suspendisse et, purus euismod posuere sit. Risus dui ut viverra venenatis ipsum tincidunt non, proin. Euismod pharetra sit ac nisi. Erat lacus, amet quisque urna faucibus. Rhoncus praesent faucibus rhoncus nec adipiscing tristique sed facilisis velit.
                              <br><br>
                              Neque nulla porta ut urna rutrum. Aliquam cursus arcu tincidunt mus dictum sit euismod cum id. Dictum integer ultricies arcu fermentum fermentum sem consectetur. Consectetur eleifend aenean eu neque euismod amet parturient turpis vitae. Faucibus ipsum felis et duis fames.
                          </p>
                          """,
            })
            .ToArray();
    }

    public static IEnumerable<BlogCategory> Categories { get; }

    public static IEnumerable<Author> Authors { get; }

    public static IEnumerable<BlogPost> Posts { get; }
}
