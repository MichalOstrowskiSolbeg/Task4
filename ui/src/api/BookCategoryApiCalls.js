const baseUrl = `https://localhost:44321/api/BookCategory`

export function getBookCategories() {
    return fetch(baseUrl);
}

export function getBookCategory(Id) {
    return fetch(`${baseUrl}/${Id}`);
}

export function getAvailableBooks() {
    return fetch(`${baseUrl}/available`);
}


export function changeStatus(Id) {
    const options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    }

    return fetch(`${baseUrl}/status/${Id}`, options);
}


export function addBookCategory(data) {
    const dataString = JSON.stringify(data)
    const options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: dataString
    }

    return fetch(`${baseUrl}`, options);
}

export function updateBookCategory(data) {
    const dataString = JSON.stringify(data)
    const options = {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: dataString
    }

    return fetch(`${baseUrl}`, options);
}

export function deleteBookCategory(Id) {
    const options = {
        method: 'Delete',
        headers: {
            'Content-Type': 'application/json'
        }
    }

    return fetch(`${baseUrl}/${Id}`, options);
}

export function changePositionUp(Id) {
    const options = {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        }
    }

    return fetch(`${baseUrl}/up/${Id}`, options);
}

export function changePositionDown(Id) {
    const options = {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        }
    }

    return fetch(`${baseUrl}/down/${Id}`, options);
}