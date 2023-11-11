namespace MKW.Domain.Dto.DTO.AwardDTO
{
    public class AwardPurchaseDto
    {
        public int NecessaryCoins { get; set; }
        public bool Sucessful { get; set; }
        public string CheckoutUrl { get; set; }
        public GivenAwardDto Award { get; set; }
    }
}
