import { useState, useEffect, useMemo } from 'react';
import { useGlobalFilter, useTable, useSortBy } from 'react-table'
import { GlobalFilter } from "./globalFilter";
import './table.css';
import { Link } from 'react-router-dom';

export function ListData(props) {
    //const [err, setErr] = useState('');
    //const [isLoading, setIsLoading] = useState(false);

    const [products, setProducts] = useState([])
    //"https://fakestoreapi.com/products"
    //"https://jsonplaceholder.typicode.com/posts"

    const URL = "https://localhost:7014/api/schooladmins/students"

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
                id: "Show",
                Header: "Show",
                Cell: ({ row }) => (
                    //row.values.id
                    //console.log(row.values.id),
                    <button style={{ cursor: 'pointer' }}
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
        <>  
            <GlobalFilter
                preGlobalFilteredRows={preGlobalFilteredRows}
                setGlobalFilter={setGlobalFilter}
                globalFilter={state.globalFilter}
            />
            <table {...getTableProps()} style={{ border: 'solid 1px blue' }} className="productsTable">
                <thead>
                    {headerGroups.map(headerGroup => (
                        <tr {...headerGroup.getHeaderGroupProps()}>
                            {headerGroup.headers.map(column => (
                                <th
                                    {...column.getHeaderProps(column.getSortByToggleProps())}
                                    style={{
                                        borderBottom: 'solid 3px blue',
                                        background: 'aliceblue',
                                        color: 'black',
                                        fontWeight: 'bold',
                                        cursor: 'pointer'
                                    }}
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
                                            style={{
                                                padding: '10px',
                                                border: 'solid 1px gray',
                                            }}
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
        </>
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