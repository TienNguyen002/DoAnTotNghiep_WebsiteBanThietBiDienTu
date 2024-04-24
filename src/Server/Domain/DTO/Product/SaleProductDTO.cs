﻿using Domain.DTO.Color;

namespace Domain.DTO.Product
{
    public class SaleProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public IList<ProductColorDTO> Colors { get; set; } = new List<ProductColorDTO>();
        public decimal SalePrice { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
    }
}
