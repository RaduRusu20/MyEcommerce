import * as React from "react";
import ImageList from "@mui/material/ImageList";
import ImageListItem from "@mui/material/ImageListItem";
import Box from "@mui/material/Box";
import HomePageStyle from "../style/HomePage.module.css";
import Layout from "../Layouts/CustomerLayout";
import { useGlobalContext } from "../components/Cart/context";
import { useEffect } from "react";
import { UserContext } from "../Services/UserContext";

function srcset(image, size, rows = 1, cols = 1) {
  return {
    src: `${image}?w=${size * cols}&h=${size * rows}&fit=crop&auto=format`,
    srcSet: `${image}?w=${size * cols}&h=${
      size * rows
    }&fit=crop&auto=format&dpr=2 2x`,
  };
}

export default function Home() {
  return (
    <Layout>
      <Box display={"flex"}>
        <ImageList
          sx={{ width: 500, height: "fit" }}
          variant="quilted"
          cols={4}
          rowHeight={121}
        >
          {itemData.map((item) => (
            <ImageListItem
              key={item.img}
              cols={item.cols || 1}
              rows={item.rows || 1}
            >
              <img
                className={HomePageStyle.popup}
                {...srcset(item.img, 121, item.rows, item.cols)}
                alt={item.title}
                loading="lazy"
              />
            </ImageListItem>
          ))}
        </ImageList>

        <ImageList
          sx={{ width: 500, height: "fit" }}
          variant="quilted"
          cols={4}
          rowHeight={121}
        >
          {itemData.map((item) => (
            <ImageListItem
              key={item.img}
              cols={item.cols || 1}
              rows={item.rows || 1}
            >
              <img
                className={HomePageStyle.popup}
                {...srcset(item.img, 121, item.rows, item.cols)}
                alt={item.title}
                loading="lazy"
              />
            </ImageListItem>
          ))}
        </ImageList>

        <ImageList
          sx={{ width: 500, height: "fit" }}
          variant="quilted"
          cols={4}
          rowHeight={121}
        >
          {itemData.map((item) => (
            <ImageListItem
              key={item.img}
              cols={item.cols || 1}
              rows={item.rows || 1}
            >
              <img
                className={HomePageStyle.popup}
                {...srcset(item.img, 121, item.rows, item.cols)}
                alt={item.title}
                loading="lazy"
              />
            </ImageListItem>
          ))}
        </ImageList>
      </Box>
    </Layout>
  );
}

const itemData = [
  {
    img: "https://th.bing.com/th/id/OIP.xSeNO47h8lm99IXvUKd62wHaE8?pid=ImgDet&rs=1",
    rows: 2,
    cols: 2,
  },
  {
    img: "https://th.bing.com/th/id/R.295a9e982cd755331b1afbd279bb389b?rik=SDP51%2brJsrf0iQ&pid=ImgRaw&r=0",
  },
  {
    img: "https://conversation.which.co.uk/wp-content/uploads/2020/02/convo_online-shopping.jpg",
  },
  {
    img: "https://th.bing.com/th/id/OIP.T5SAqJ8P6xOUkljSxd8trgHaEk?pid=ImgDet&rs=1",
    cols: 2,
  },
  {
    img: "https://image.freepik.com/free-vector/shopping-online-design_24877-39677.jpg",
    cols: 2,
  },
  {
    img: "https://th.bing.com/th/id/R.bb8fd0bed25ef946290abf3424f37717?rik=NT%2f9P%2ftoYxeZ6w&riu=http%3a%2f%2fwww.icisonneries.com%2fwp-content%2fuploads%2f2020%2f08%2fECC5998B-min-15.jpg&ehk=mZEa9MHd%2fEmzHwLHJie09ancbh66FiLEpQ%2b%2bV8QSveI%3d&risl=&pid=ImgRaw&r=0",
    rows: 2,
    cols: 2,
  },
  {
    img: "https://th.bing.com/th/id/R.54fff027108ba03712b8fd698260118c?rik=IRibSdXF9FxWIQ&pid=ImgRaw&r=0",
  },
  {
    img: "https://th.bing.com/th/id/OIP.yPxPy5fCNfWBCZb0p1nzEwHaIb?pid=ImgDet&rs=1",
  },
  {
    img: "https://graphicsfamily.com/wp-content/uploads/edd/2020/12/Free-Logo-Design-Template-for-Online-Store-PSD-source.jpg",
    rows: 2,
    cols: 2,
  },
  {
    img: "https://image.shutterstock.com/image-vector/shopping-online-design-vector-illustration-600w-438860692.jpg",
  },
  {
    img: "https://th.bing.com/th/id/OIP.jYFNM0imGp5oYs2f8Q6OqgHaHa?pid=ImgDet&rs=1",
  },
  {
    img: "https://th.bing.com/th/id/R.cfd7e0732cb3d5206851c8783a2a24fe?rik=jdsf6ssxICdDug&riu=http%3a%2f%2fst2.depositphotos.com%2f2951317%2f10236%2fv%2f950%2fdepositphotos_102362356-stock-illustration-online-shopping-concept-with-vector.jpg&ehk=lMgfGkQsWOgQReIe4AI1h0yB4MU5EKnHk624Z09hN2c%3d&risl=&pid=ImgRaw&r=0",
    cols: 2,
  },
];
