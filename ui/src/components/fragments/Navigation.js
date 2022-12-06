import React from 'react';
import { NavLink } from "react-router-dom";
import { Link } from "react-router-dom";

function Navigation() {
    return (
        <nav>           
            <ul>
                <Link to={'/'}><img src="/book.png" alt="logo" width="100" height="100" /></Link>
                <li><NavLink to='/' >Main menu</NavLink></li>
                <li><NavLink to="/books" >Books</NavLink></li>
                <li><NavLink to="/my_books" >My books</NavLink></li>
            </ul>
        </nav>
    )
}

export default Navigation;