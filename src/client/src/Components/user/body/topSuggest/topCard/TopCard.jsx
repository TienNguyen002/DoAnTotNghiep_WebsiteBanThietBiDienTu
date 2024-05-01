import React from "react";
import StarRating from "../../../product/starRating/StarRating";
import { Award } from "lucide-react";
import product from "../../../../../Shared/data/product.json";
import { formatVND } from "../../../../../Common/function";
import "./topCard.scss";
import { Link, useNavigate } from "react-router-dom";

const TopCard = (props) => {
  const { title, isNew, products } = props;
  const navigate = useNavigate();

  const handleLink = () => {
    navigate("/detail");
    window.scrollTo({
      top: 0,
      behavior: "instant",
    });
  };

  return (
    <>
      <div className="top-card">
        <div className="top-card-header">
          <div className="top-card-header-title">
            <Award />
            {title}
          </div>
          {/* <div className="top-card-header-more">
            Xem tất cả <ChevronRight />
          </div> */}
        </div>
        <div className="top-card-product">
          {products ? (
            <>
              {products.map((item, index) => (
                <div
                  className="top-card-product-detail"
                  key={index}
                  onClick={handleLink}
                >
                  <img
                    src={item.imageUrl}
                    alt={item.name}
                    className="top-card-product-detail-image"
                  />
                  <div className="top-card-product-detail-item">
                    <h3 className="top-card-product-detail-item-name">
                      {item.name}
                    </h3>
                    <div className="top-card-product-detail-item-price">
                      <div className="top-card-product-detail-item-price-current">
                        <p>{formatVND(item.price)}</p>
                      </div>
                      <div className="top-card-product-detail-item-price-original">
                        <s>{formatVND(item.orPrice)}</s>
                      </div>
                    </div>
                    {isNew ? null : (
                      <StarRating
                        rating={item.rating}
                        className="product-box-detail-rating"
                      />
                    )}
                  </div>
                </div>
              ))}
            </>
          ) : null}
        </div>
        <Link to={"/sale"} onClick={handleLink} className="top-card-more">
          Xem tất cả
        </Link>
      </div>
    </>
  );
};

export default TopCard;
