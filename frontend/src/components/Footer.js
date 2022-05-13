import React from "react";
import HomePageStyle from "../style/HomePage.module.css";
import Box from "@mui/material/Box";
import FacebookIcon from "@mui/icons-material/Facebook";
import TwitterIcon from "@mui/icons-material/Twitter";
import LinkedInIcon from "@mui/icons-material/LinkedIn";
import YouTubeIcon from "@mui/icons-material/YouTube";
import { Link } from "react-router-dom";

const Footer = () => (
  <footer className={HomePageStyle.footer}>
    <Box gap={7} display={"flex"}>
      <Box className={HomePageStyle.footerText}>
        <h5 className={HomePageStyle.footerTitles}>Despre MyEcommerce</h5>
        <br />
        <p> Despre noi</p>
        <p>Cariere</p>
        <p>MyEcommerce recomanda</p>
        <p>Branduri disponibile</p>
        <Link to={"/categories"} className={HomePageStyle.link}>
          <p>Categorii produse</p>
        </Link>
        <p>Vanzari Corporate</p>
        <p>Tax free</p>
      </Box>

      <Box className={HomePageStyle.footerText}>
        <h5 className={HomePageStyle.footerTitles}>Suport clienti</h5>
        <br />
        <p> Articole suport</p>
        <p>Contact</p>
        <p>Returneaza produse</p>
        <p>Reteaua de magazine MyEcommerce</p>
      </Box>

      <Box className={HomePageStyle.footerText}>
        <h5 className={HomePageStyle.footerTitles}>Informatii legale</h5>
        <br />
        <p> Termeni si conditii</p>
        <p>Politica de utilizare Cookie-uri</p>
        <p>Informatii privind DEEE</p>
        <p>ANPC</p>
        <p>Protectia datelor cu caracter personal</p>
      </Box>

      <Box className={HomePageStyle.footerText}>
        <h5 className={HomePageStyle.footerTitles}>Contact</h5>
        <br />
        <p>Telefon: 021 / 9196</p>
        <p>Fax: 021 / 319.99.39</p>
      </Box>

      <Box className={HomePageStyle.footerText}>
        <h5 className={HomePageStyle.footerTitles}>Urmareste-ne</h5>
        <br />
        <Box gap={0.7} display={"flex"}>
          <a
            className={HomePageStyle.link}
            href="https://www.facebook.com/thisisamdaris/?ref=page_internal"
            target="_blank"
          >
            <FacebookIcon />
          </a>
          <a
            className={HomePageStyle.link}
            href="https://twitter.com/Amdaris"
            target="_blank"
          >
            <TwitterIcon />
          </a>
          <a
            className={HomePageStyle.link}
            href="https://www.linkedin.com/"
            target="_blank"
          >
            <LinkedInIcon />
          </a>
          <a
            className={HomePageStyle.link}
            href="https://www.youtube.com/channel/UCyTPru-1gZ7-4qblcKM0TiQ"
            target="_blank"
          >
            <YouTubeIcon />
          </a>
        </Box>
      </Box>
    </Box>
  </footer>
);

export default Footer;
