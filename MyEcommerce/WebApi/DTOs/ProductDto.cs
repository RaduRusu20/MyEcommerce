﻿namespace WebApi.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int AvailableQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public string Img { get; set; }
        public Guid Id { get; set; }
    }
}
