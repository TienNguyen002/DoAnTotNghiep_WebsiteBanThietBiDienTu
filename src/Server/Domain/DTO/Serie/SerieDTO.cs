﻿using Domain.DTO.Branch;
using Domain.DTO.Category;
using Domain.DTO.Comment;
using Domain.DTO.Image;
using Domain.DTO.Product;

namespace Domain.DTO.Serie
{
    public class SerieDTO
    {
        public string Name { get; set; } = null!;
        public string UrlSlug { get; set; } = null!;
        public float Rating { get; set; }
        public string Description { get; set; } = null!;
        public CategoryProductDTO Category { get; set; }
        public BranchProductDTO Branch { get; set; }
        public IList<CommentDTO> Comments { get; set; }
        public IList<ImageDTO> Images { get; set; }
        public IList<SerieProductDTO> Products { get; set; }
    }
}
