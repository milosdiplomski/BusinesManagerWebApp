// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
async function deleteProduct(id, xCsrfToken) {
    if(confirm('Are you sure?')) {
        await fetch(`Client/Index/${id}`, {
            method: 'delete',
            headers: {
                'X-CSRF-TOKEN': xCsrfToken
            }
        })
        .then(function (response) {
            if (response.status === 204) {
                location.reload();
            }
            else {
                throw `Unable to delete product. HTTP status code: ${response.status}`;
            }
        })
        .catch((error) => {
            document.getElementById('spanError').innerText = error;
            console.log(`Product ID ${id}. ${error}`);
        });
    }
}