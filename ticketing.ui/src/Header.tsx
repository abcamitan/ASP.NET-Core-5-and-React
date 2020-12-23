import React from 'react';
import './Header.css';
import logo from './logo.svg';
import Navbar from 'react-bootstrap/Navbar'

export const Header: React.FC = () => ( 
    <> 
        <Navbar bg="light" variant="light">
            <Navbar.Brand href="#home" className="Header-navbar">
                <img
                    alt=""
                    src={ logo }
                    width="100"
                    height="100"
                    className="d-inline-block align-top Header-logo"
                />{' '}
                Ticketing System
            </Navbar.Brand>
        </Navbar>
    </> 
);
