import React from "react";
import { getBookCategory, addBookCategory, updateBookCategory, getAvailableBooks } from "../../api/BookCategoryApiCalls";
import { getCategories } from "../../api/CategoryApiCalls";
import formMode from "../../helperFunctions/formEnums"
import { useNavigate } from "react-router";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";

class BookCategoryForm extends React.Component {
    constructor(props) {
        super(props);
        const id = this.props.params.Id
        const mode = id != null ? formMode.EDIT : formMode.NEW

        this.state = {
            error: '',
            isLoaded: false,
            data: {
                BookId: '',
                CategoryId: '',
                IsRead: false
            },
            errors: {
                BookId: '',
                CategoryId: '',
                IsRead: ''
            },
            books: [],
            categories: [],
            id: id,
            mode: mode
        }
    }

    getBookData() {
        getBookCategory(this.state.id).then(res => res.json())
            .then(
                (data) => {
                    console.log(data)
                    this.setState({
                        data: data
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
        if (this.state.mode === formMode.EDIT) {
            this.getBookData()
        }

        getAvailableBooks().then(res => res.json())
            .then(
                (data) => {
                    console.log(data)
                    this.setState({
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

        getCategories().then(res => res.json())
            .then(
                (data) => {
                    this.setState({
                        categories: data
                    });
                },
                (error) => {
                    console.log(error)
                    this.setState({
                        error: error
                    });
                }
            )

        this.setState({
            isLoaded: true,
        })
    }


    handleChange = (event) => {
        const { name, value, checked } = event.target
        const bookCategory = { ...this.state.data }
        if (name === 'IsRead') {
            bookCategory[name] = checked
        } else {
            bookCategory[name] = value
        }

        const errorMessage = this.validateField(name, value)
        const errors = { ...this.state.errors }
        errors[name] = errorMessage

        this.setState({
            data: bookCategory,
            errors: errors
        })
    }

    validateField = (fieldName, fieldValue) => {
        let errorMessage = '';
        if (fieldName === 'BookId') {
            if (!fieldValue) {
                errorMessage = 'Required'
            }
        }
        if (fieldName === 'CategoryId') {
            if (!fieldValue) {
                errorMessage = 'Required'
            }
        }
        return errorMessage
    }

    validateForm = () => {
        const data = this.state.data
        const errors = this.state.errors
        for (const fieldName in data) {
            const fieldValue = data[fieldName]
            const errorMessage = this.validateField(fieldName, fieldValue)
            errors[fieldName] = errorMessage
        }
        this.setState({
            errors: errors
        })
        return !this.hasErrors();
    }

    hasErrors = () => {
        const errors = this.state.errors
        for (const errorField in this.state.errors) {
            if (errors[errorField].length > 0) {
                return true
            }
        }
        return false
    }

    handleSubmit = (event) => {
        const { navigate } = this.props;
        event.preventDefault();
        const isValid = this.validateForm()
        if (isValid) {
            const req = this.state.data
            const currentFormMode = this.state.mode
            let promise
            if (currentFormMode === formMode.NEW) {
                promise = addBookCategory(req)
            } else if (currentFormMode === formMode.EDIT) {
                const newRequest = {
                    BookId: req['BookId'],
                    IsRead: req['IsRead'],
                    CategoryId: req['CategoryId']
                }
                promise = updateBookCategory(newRequest)
            }
            if (promise) {
                promise
                    .then(
                        (response) => {
                            if (response.ok) {
                                navigate("/my_books", { replace: true });
                            } else {
                                return response.json()
                            }
                        })
                    .then(
                        (data) => {
                            console.log(data)
                        },
                        (error) => {
                            this.setState(
                                {
                                    error: error
                                })
                            console.log(error)
                        }
                    )
            }
        }
    }

    render() {
        const { data, mode, isLoaded, error, books, categories } = this.state
        const pageTitle = mode === formMode.NEW ? 'Add' : `Edit`
        let content;

        if (error) {
            content = <p>Error: {error}</p>
        } else if (!isLoaded) {
            content = <p>Loading...</p>
        } else {
            content =
                <form className="form" onSubmit={this.handleSubmit} noValidate>
                    <label form="BookId">Book: <span className="symbol-required">*</span></label>
                    {mode === formMode.NEW &&
                        <select name="BookId" id="BookId" onChange={this.handleChange} className={this.state.errors.BookId === '' ? '' : 'error-input'}>
                            <option defaultValue value="">--Select book--</option>
                                {books.map(b => (
                                    <option
                                        value={b.Id} label={b.Title} />
                                ))}
                            </select>
                    }
                    {mode === formMode.EDIT &&
                        <input type="text" className="" name="BookId" id="BookId" value={data.Title} disabled />
                    }
                    <span id="errorBookId" className="errors-text">{this.state.errors.BookId}</span>

                    <label form="CategoryId">Category: <span className="symbol-required">*</span></label>
                    <select name="CategoryId" id="CategoryId" onChange={this.handleChange}
                        className={this.state.errors.CategoryId === '' ? '' : 'error-input'}>
                        <option value="">--Select category--</option>
                        {categories.map(c => (
                            <option selected={this.state.data.CategoryId === c.Id}
                                value={c.Id} label={c.CategoryText} />
                        ))}
                    </select>
                    <span id="errorCategoryId" className="errors-text">{this.state.errors.CategoryId}</span>

                    <label htmlFor="IsRead">Is Read?</label>
                    <input type="checkbox" name="IsRead" id="IsRead" checked={data.IsRead} onChange={this.handleChange} />
                    <span id="errorIsRead"></span>

                    <div className="form-buttons">
                        <input type="submit" className="form-button-submit" value="Submit" />
                        <Link to={`/my_books`} className="form-button-cancel">Back</Link>
                    </div>
                </form>
        }

        return (
            <main>
                <h1>{pageTitle}</h1>
                {content}
            </main>
        )
    }
}

const withRouter = WrappedComponent => props => {
    const params = useParams();
    const navigate = useNavigate();

    return (
        <WrappedComponent
            {...props}
            params={params}
            navigate={navigate}
        />
    );
};

export default withRouter(BookCategoryForm);