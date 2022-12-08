function BookListTable(props) {
    const data = props.books
    return (
        <>
            <table className="table-list">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Year</th>
                        <th>Author(s)</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(x =>
                        <tr key={x.Id}>
                            <td>{x.Title}</td>
                            <td>{x.Year != null ? x.Year : '-'}</td>
                            <td>{x.Authors}</td>
                            <td>

                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </>
    )
}

export default BookListTable