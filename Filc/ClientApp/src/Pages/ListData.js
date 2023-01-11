import { useState, useEffect, useMemo } from 'react';
import { useGlobalFilter, useTable, useSortBy } from 'react-table'
import { GlobalFilter } from "./globalFilter";
import '../Style/Shared/table.css';
import { Link } from 'react-router-dom';

export function ListData(props) {
    //const [err, setErr] = useState('');
    //const [isLoading, setIsLoading] = useState(false);

    const [products, setProducts] = useState([])
    //"https://fakestoreapi.com/products"
    //"https://jsonplaceholder.typicode.com/posts"

    //const URL = "https://localhost:7014/api/schooladmins/students"

    useEffect(() => {
        let isCancelled = false;
        apiGet(props.URL)
            .then((data) => {
                if (!isCancelled) {
                    setProducts(data);
                    console.log(data)
                }
            });
        return () => {
            console.log("cancelled")
            isCancelled = true;
        };
    }, [props]);

    const productsData = useMemo(
        () => [...products], [products]);  

    
   

    const productsColumns = useMemo(
        () =>
            products[0]
                ? Object.keys(products[0])
                    .filter((key) => key !== "teachers" && key !== "lessons" && key !== "marks" && key !== "school" && key !== "user" && key !== "subjects"
                                  && key !== "students" && key !== "schoolAdmin" && key !== "lessons" && key !== "classes")
                    .map((key) => {
                        if (key === "image")
                            return {
                                Header: key,
                                accessor: key,
                                Cell: ({ value }) => <img src={value} className="picture" />,
                                //maxWidth: 70,
                            };
                        if (key === "price")
                            return {
                                Header: key,
                                accessor: key,
                                Cell: ({ value }) => formatMoney(value),
                            };
                        return { Header: key, accessor: key };
                    })
                : [],
        [products]
    );
    
    const tableHooks = (hooks) => {
       
        hooks.visibleColumns.push((columns) => [
            ...columns,
            {   
                id: "Details",
                Header: "Details",
                Cell: ({ row }) => (
                    //row.values.id
                    //console.log(row.values.id),
                    <button className="showButtons"
                        onClick={() => console.log(row.values.id)}>
                        <Link to={`${window.location.pathname}/${row.values.id}`}>Show</Link>                       
                    </button>
                ),
            },
        ]);
    };

    const tableInstance = useTable(
        {
            columns: productsColumns,
            data: productsData,
        },
        useGlobalFilter,
        tableHooks,
        useSortBy
    );

    const {
        getTableProps,
        getTableBodyProps,
        headerGroups,
        rows,
        prepareRow,
        preGlobalFilteredRows,
        setGlobalFilter,
        state,
    } = tableInstance;

    const isEven = (index) => index % 2 === 0;
    
    return (   
        <div className="wrapper">  
            <GlobalFilter
                preGlobalFilteredRows={preGlobalFilteredRows}
                setGlobalFilter={setGlobalFilter}
                globalFilter={state.globalFilter}
            />
            <table {...getTableProps()} className="dataTable">
                <thead className="tHeads">
                    {headerGroups.map(headerGroup => (
                        <tr className="tHeadRows"
                            {...headerGroup.getHeaderGroupProps()}>
                            {headerGroup.headers.map(column => (
                                <th
                                    {...column.getHeaderProps(column.getSortByToggleProps())}
                                    className="tableHeaders"
                                    
                                >
                                    {column.render('Header')}
                                    {column.isSorted ? (column.isSortedDesc ? " ▼" : " ▲") : ""}
                                </th>
                            ))}
                        </tr>
                    ))}
                </thead>
                <tbody {...getTableBodyProps()}>
                    {rows.map((row, index) => {
                        prepareRow(row)
                        return (
                            <tr className={isEven(index) ? "row-even" : "row-odd"} {...row.getRowProps()}>
                                {row.cells.map(cell => {
                                    return (
                                        <td
                                            className="col"
                                            {...cell.getCellProps()}
                                            
                                        >
                                            {cell.render('Cell')}
                                        </td>
                                    )
                                })}
                            </tr>
                        )
                    })}
                </tbody>
            </table>
        </div>
    )
}

async function apiGet(url) {
    let response = await fetch(url, {
        method: 'GET',
        headers: {
            "Authorization": "Bearer " + localStorage.getItem("AccessToken")
        }
    });
    if (!response.ok) {
        throw new Error(`Something went wrong during fetching data from ${url}`)
    } else {
        return await response.json()
    }
}

const formatMoney = (value) => {
    if (value) {
        return `$${value.toFixed(2)}`;
    } else {
        return "-";
    }
};