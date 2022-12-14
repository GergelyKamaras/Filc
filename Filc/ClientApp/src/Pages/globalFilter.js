import React, { useState } from "react";
import { useAsyncDebounce } from "react-table";


export function GlobalFilter({
    preGlobalFilteredRows,
    globalFilter,
    setGlobalFilter,
}) {
    const count = preGlobalFilteredRows.length;
    const [value, setValue] = useState(globalFilter);
    const onChange = useAsyncDebounce((value) => {
        setGlobalFilter(value || undefined);
    }, 300);

    
    return (
        <div>
            <p>Search:</p>
            <input
                value={value || ""}
                onChange={(e) => {
                    setValue(e.target.value);
                    onChange(e.target.value);
                }}
                placeholder={count ? (count > 1 ? `${count} records...` : `${count} record...`): ""}
            />
        </div>
    );
}