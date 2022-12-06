import React from "react";
import { getBooks } from "../../api/BookApiCalls";
import BookListTable from "./BookListTable";

class BookList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            books: [],
        }
    }

    getBookData() {
        getBooks()
            .then(res => res.json())
            .then(
                (data) => {
                    this.setState({
                        isLoaded: true,
                        books: data
                    });
                },
                (error) => {
                    console.log(error)
                    this.setState({
                        error: error
                    });
                }
            )
    }

    componentDidMount() {
        this.getBookData()
    }

    render() {
        const { error, isLoaded, books } = this.state
        let content;

        if (error) {
            content = <p>Error: {error}</p>
        } else if (!isLoaded) {
            content = <p>Loading...</p>
        } else {
            content = <BookListTable books={books} />
        }

        return (
            <main>
                <h1>Books</h1>
                <p>List of all books</p>
                {content}
            </main>
        )
    }
}

export default BookList;