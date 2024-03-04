﻿using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Màu sản phẩm
    public class Color : IEntity
    {
        //Mã màu sản phẩm
        public int Id { get; set; }

        //Màu sản phẩm
        public string Name { get; set; }

        //Mã định danh
        public string UrlSlug { get; set; }

        //Danh sách sản phẩm
        public IList<Variant> Variants { get; set; }
    }
}
