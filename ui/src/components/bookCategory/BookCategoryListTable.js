import { getFormattedDate } from '../../helperFunctions/dateFormat';
import { Link } from "react-router-dom";
import { changeStatus } from '../../api/BookCategoryApiCalls';

function BookCategoryListTable(props) {
    const data = props.data
    return (
        <>
            <table className="table-list">
                <thead>
                    <tr>
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
                            <td>{x.Title}</td>
                            <td>{getFormattedDate(x.WhenAdded)}</td>
                            <td>{x.Category}</td>
                            <td>
                                <label class="switch">
                                    <input type="checkbox" defaultChecked={x.IsRead} onClick={() => changeStatus(x.BookId)} />
                                    <span class="slider round"></span>
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