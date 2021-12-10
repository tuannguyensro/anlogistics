$('#addRow').on('click', function () {
    // Adding a row inside the tbody.
    $('#addorder').append(`                            <tr>
                                <td>
                                    <a>
                                        <input id="ProductLink" class="form-control"
                                               type="text"
                                               placeholder="Default input" />
                                    </a>
                                </td>
                                <td>
                                    <a>
                                        <div id="ProductImage" class="custom-file">
                                            <input type="file"
                                                   class="custom-file-input"
                                                   id="ProductImage1" />
                                            <label class="custom-file-label"
                                                   for="ProductImage1">Choose file</label>
                                        </div>
                                    </a>
                                </td>
                                <td>
                                    <a>
                                        <input id="ProductName" class="form-control"
                                               type="text"
                                               placeholder="Default input" />
                                    </a>
                                </td>
                                <td>
                                    <a>
                                        <input id="ProductDetail" class="form-control"
                                               type="text"
                                               placeholder="Default input" />
                                    </a>
                                </td>
                                <td>
                                    <a>
                                        <input id="Quantity" class="form-control"
                                               type="text"
                                               placeholder="Default input" />
                                    </a>
                                </td>
                                <td>
                                    <a>
                                        <input id="Description" class="form-control"
                                               type="text"
                                               placeholder="Default input" />
                                    </a>
                                </td>
                                <td>
                                    <button class="btn btn-block btn-danger">Xóa</button>
                                </td>
                            </tr>`);
});