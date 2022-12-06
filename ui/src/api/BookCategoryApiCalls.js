const baseUrl = `https://localhost:44321/api/BookCategory`

export function getBookCategories() {
    return fetch(baseUrl);
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