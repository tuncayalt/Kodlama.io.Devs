namespace Application.Features.Technologies.Dtos
{
    public class GetByIdTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}
