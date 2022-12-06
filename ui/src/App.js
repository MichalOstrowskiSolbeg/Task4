import React, { Component } from 'react';
import {
    Routes,
    Route, BrowserRouter,
} from "react-router-dom";
import BookList from './components/book/BookList';
import BookCategoryList from './components/bookCategory/BookCategoryList';
import Footer from './components/fragments/Footer';
import Navigation from './components/fragments/Navigation';
import MainPage from './components/other/MainPage';

export default class App extends Component {
    static displayName = App.name;
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            loading: true
        };
    }

    render() {
        return (
            <BrowserRouter>
                <Navigation />
                <Routes>
                    <Route path="/" element={<MainPage />} />
                    <Route path="/books" element={<BookList />} />

                    <Route path="/my_books" element={<BookCategoryList />} />
                </Routes>
                <Footer />
            </BrowserRouter>
        );
    }
}