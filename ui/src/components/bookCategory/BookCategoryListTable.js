import { getFormattedDate } from '../../helperFunctions/dateFormat';
import { Link } from "react-router-dom";
import { changePositionUp, changePositionDown, changeStatus } from '../../api/BookCategoryApiCalls';
import { useNavigate } from "react-router";

function BookCategoryListTable(props) {
    const navigate = useNavigate();
    const data = props.data
    return (
        <>
            <table className="table-list">
                <thead>
                    <tr>
                        <th>Position</th>
                        <th>Title</th>
                        <th>When added</th>
                        <th>Category</th>
                        <th>Is read?</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(x =>
                        <tr key={x.BookId}>
                            <td>
                                <a type="button" onClick={() => {
                                    changePositionDown(x.BookId)
                                        .then(res => {
                                            console.log(res)
                                            if (res.ok) {
                                                navigate(0, { replace: true });
                                            }
                                        })
                                    }
                                }
                                    id="b-minus" className="button-down">&#8595;
                                </a>
                                <a type="button" onClick={() => {
                                    changePositionUp(x.BookId)
                                        .then(res => {
                                            console.log(res)
                                            if (res.ok) {
                                                navigate(0, { replace: true });
                                            }
                                        })
                                    }
                                }
                                    id="b-plus" className="button-up">&uarr;
                                </a>
                            </td>
                            <td>{x.Title}</td>
                            <td>{getFormattedDate(x.WhenAdded)}</td>
                            <td>{x.Category}</td>
                            <td>
                                <label className="switch">
                                    <input type="checkbox" defaultChecked={x.IsRead} onClick={() => changeStatus(x.BookId)} />
                                    <span className="slider round"></span>
                                </label>
                            </td>
                            <td>
                                <ul className="list-actions">
                                    <li><Link to={`/my_books/details/${x.BookId}`}
                                        className="list-actions-button-details">Details</Link></li>
                                    <li><Link to={`/my_books/edit/${x.BookId}`}
                                        className="list-actions-button-edit">Edit</Link></li>
                                    <li><Link to={`/my_books/delete/${x.BookId}`}
                                        className="list-actions-button-delete">Delete</Link></li>
                                </ul>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>

            <form className="form">
                <div className="form-buttons">
                    <Link to={`/my_books/add`} className="form-button-submit">Add book</Link>
                </div>
            </form>
        </>
    )
}

export default BookCategoryListTable