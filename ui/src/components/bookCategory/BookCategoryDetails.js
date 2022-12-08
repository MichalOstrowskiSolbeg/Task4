import React from "react";
import { getBookCategory } from "../../api/BookCategoryApiCalls";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import { getFormattedDate } from '../../helperFunctions/dateFormat';

class BookCategoryDetails extends React.Component {
    constructor(props) {
        super(props);
        const id = this.props.params.Id

        this.state = {
            error: null,
            isLoaded: false,
            data: {
                BookId: '',
                CategoryId: '',
                IsRead: '',
                WhenAdded: ''
            },
            errors: {
                BookId: '',
                CategoryId: '',
                IsRead: '',
                WhenAdded: ''
            },
            id: id
        }
    }

    getBookData() {
        getBookCategory(this.state.id).then(res => res.json())
            .then(
                (data) => {
                    console.log(data)
                    this.setState({
                        isLoaded: true,
                        data: data
                    });
                },
                (error) => {
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
        const { errors, data, mode } = this.state

        return (
            <main>
                <h1>Details</h1>
                <form className="form">
                    <label htmlFor="Title">Book</label>
                    <input type="text" className="" name="Title" id="Title" placeholder="" value={data.Title} disabled />
                    <span id="errorTitle" className="errors-text"></span>

                    <label htmlFor="Category">Category</label>
                    <input type="text" className="" name="Category" id="Category" placeholder="" value={data.Category} disabled />
                    <span id="errorCategory" className="errors-text"></span>

                    <label htmlFor="IsRead">Is Read?</label>
                    <input type="text" className="" name="IsRead" id="IsRead" placeholder="" value={data.IsRead ? 'Yes' : 'No'} disabled />
                    <span id="errorIsRead" className="errors-text"></span>

                    <label htmlFor="WhenAdded">When Added</label>
                    <input type="text" className="" name="WhenAdded" id="WhenAdded" placeholder="" value={getFormattedDate(data.WhenAdded)} disabled />
                    <span id="errorWhenAdded" className="errors-text"></span>

                    <div className="form-buttons">
                        <Link to={`/my_books/edit/${this.state.id}`} className="form-button-edit">Edit</Link>
                        <Link to={`/my_books`} className="form-button-cancel">Back</Link>
                    </div>
                </form>
            </main>
        )
    }
}

const withRouter = WrappedComponent => props => {
    const params = useParams();

    return (
        <WrappedComponent
            {...props}
            params={params}
        />
    );
};

export default withRouter(BookCategoryDetails);