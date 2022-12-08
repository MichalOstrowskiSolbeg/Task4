import React from "react";
import { getBookCategories, changePositionUp, changePositionDown } from "../../api/BookCategoryApiCalls";
import BookCategoryListTable from "./BookCategoryListTable";
import { useNavigate } from "react-router";
import { useParams } from "react-router-dom";

class BookCategoryList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            data: [],
        }
    }

    getBookData() {
        getBookCategories().then(res => res.json())
            .then(
                (data) => {
                    console.log(data)
                    this.setState({
                        isLoaded: true,
                        data: data
                    });
                },
                (error) => {
                    console.log(error)
                    this.setState({
                        isLoaded: true,
                        error: error
                    });
                }
            )
    }

    componentDidMount() {
        this.getBookData()
    }

    render() {
        const { error, isLoaded, data } = this.state
        let content;

        if (error) {
            content = <p>Error: {error}</p>
        } else if (!isLoaded) {
            content = <p>Loading...</p>
        } else {
            content = <BookCategoryListTable data={data} up={this.positionUp} down={this.positionDown} />
        }

        return (
            <main>
                <h1>My books</h1>
                <p>List of books I want to read</p>
                {content}
            </main>
        )
    }
}

export default BookCategoryList;