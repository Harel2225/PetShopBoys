@ModelType IEnumerable(Of PetShopBoys.PetVM)
@Code
    ViewData("Title") = "Our Pet List"
End Code

<h2>@ViewData("Title").</h2>
<h3>@ViewData("Message")</h3>
<style>
    img {
        height: 100px;
    }

    tbody tr:hover {
        cursor: pointer;
        background-color: rgb(0, 255, 255, 0.4)
    }
</style>
@If SessionManager.IsManager() Then
    @<p>
        @Html.ActionLink("Create New", "Create")
    </p>
End If
<form>
    <div class="form-group">
        <label for="exampleInputEmail1">From Price</label>
        <input type="number" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
    </div>
    <div class="form-group">
        <label for="exampleInputPassword1">To Price</label>
        <input type="number" class="form-control" id="exampleInputPassword1">
    </div>
    <div class="form-group">
        <label for="name">Name</label>
        <input type="text" class="form-control" id="name">
    </div>
    <button type="submit" class="btn btn-primary glyphicon-search search">Search</button>
</form>
       @* @Html.ActionLink("Search", "Search")*@
       
<Table Class="table">
        <tr>

                <th>
                CatalogID
            </th>
            <th>
                Name
            </th>
            <th>
                Price
            </th>
            <th>
                Image
            </th>

        </tr>

    @For Each item In Model
    @<tr>
        <td>
            @item.id
        </td>
        <td>
            @item.name
        </td>
        <td>
            @item.price
        </td>
        <td>
            <img src="@item.Image" alt="@item.Name" />
        </td>
        @If SessionManager.IsManager() Then
        @<td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
        </td>
                    End If
    </tr>
    Next

</Table>
