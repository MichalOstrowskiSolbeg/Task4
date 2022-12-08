import React from "react";
import { useParams } from "react-router-dom";
import { deleteBookCategory } from "../../api/BookCategoryApiCalls";
import { Navigate } from "react-router";

class BookCategoryDelete extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            redirect: false,
            Id: this.props.params.Id,
        }
    }

    componentDidMount() {
        deleteBookCategory(this.state.Id)
            .then(
                (res) => {
                    console.log(res)
                    this.setState({
                        redirect: true
                    })
                }
            )
    }

    render() {
        const { redirect } = this.state
        if (redirect) {
            return (
                <Navigate to={{
                    pathname: "/my_books"
                }} />
            )
        }
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

export default withRouter(BookCategoryDelete);