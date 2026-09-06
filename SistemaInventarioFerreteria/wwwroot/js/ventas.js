(() => {
    const currency = new Intl.NumberFormat("es-SV", {
        style: "currency",
        currency: "USD"
    });

    document.querySelectorAll(".venta-form").forEach((form) => {
        const input = form.querySelector("[data-product-input]");
        const productId = form.querySelector("[data-product-id]");
        const results = form.querySelector("[data-product-results]");
        const branch = form.querySelector("[data-branch-select]") ??
            form.querySelector('input[name="IdSucursal"]');
        const selected = form.querySelector("[data-selected-product]");
        const error = form.querySelector("[data-product-error]");
        if (!input || !productId || !results || !branch || !selected) return;

        let timer;
        let request;
        let selectedText = input.value;

        const hideResults = () => {
            results.classList.add("is-hidden");
            input.setAttribute("aria-expanded", "false");
        };

        const clearProduct = () => {
            productId.value = "";
            selected.classList.add("is-hidden");
            selected.querySelector("[data-selected-name]").textContent = "";
            selected.querySelector("[data-selected-sku]").textContent = "";
            selected.querySelector("[data-selected-price]").textContent = "";
            selected.querySelector("[data-selected-stock]").textContent = "";
            selectedText = "";
        };

        const showMessage = (message) => {
            results.replaceChildren();
            const item = document.createElement("div");
            item.className = "producto-resultado-vacio";
            item.textContent = message;
            results.append(item);
            results.classList.remove("is-hidden");
            input.setAttribute("aria-expanded", "true");
        };

        const chooseProduct = (product) => {
            productId.value = product.id;
            selectedText = `${product.nombre} · ${product.sku}`;
            input.value = selectedText;
            selected.querySelector("[data-selected-name]").textContent = product.nombre;
            selected.querySelector("[data-selected-sku]").textContent = product.sku;
            selected.querySelector("[data-selected-price]").textContent = currency.format(product.precio);
            selected.querySelector("[data-selected-stock]").textContent = product.existencia;
            selected.classList.remove("is-hidden");
            if (error) error.textContent = "";
            hideResults();
        };

        const renderProducts = (products) => {
            results.replaceChildren();
            if (!products.length) {
                showMessage("No encontramos productos con existencias para esta búsqueda.");
                return;
            }

            products.forEach((product, index) => {
                const option = document.createElement("button");
                option.type = "button";
                option.className = "producto-opcion";
                option.id = `producto-opcion-${product.id}`;
                option.setAttribute("role", "option");
                option.dataset.index = index;

                const copy = document.createElement("span");
                copy.className = "producto-opcion-copy";
                const name = document.createElement("strong");
                name.textContent = product.nombre;
                const detail = document.createElement("small");
                detail.textContent = `${product.sku} · ${product.detalle}`;
                copy.append(name, detail);

                const meta = document.createElement("span");
                meta.className = "producto-opcion-meta";
                const price = document.createElement("strong");
                price.textContent = currency.format(product.precio);
                const stock = document.createElement("small");
                stock.textContent = `${product.existencia} disponibles`;
                meta.append(price, stock);

                option.append(copy, meta);
                option.addEventListener("click", () => chooseProduct(product));
                results.append(option);
            });

            results.classList.remove("is-hidden");
            input.setAttribute("aria-expanded", "true");
        };

        const search = async () => {
            const branchId = branch.value;
            if (!branchId) {
                showMessage("Primero selecciona la sucursal de la venta.");
                return;
            }

            request?.abort();
            request = new AbortController();
            showMessage("Buscando productos…");

            const url = new URL(form.dataset.productSearchUrl, window.location.origin);
            url.searchParams.set("idSucursal", branchId);
            url.searchParams.set("termino", input.value.trim());

            try {
                const response = await fetch(url, {
                    signal: request.signal,
                    headers: { "X-Requested-With": "XMLHttpRequest" }
                });
                if (!response.ok) throw new Error();
                renderProducts(await response.json());
            } catch (searchError) {
                if (searchError.name !== "AbortError") {
                    showMessage("No fue posible cargar los productos. Intenta nuevamente.");
                }
            }
        };

        input.addEventListener("focus", search);
        input.addEventListener("input", () => {
            if (input.value !== selectedText) clearProduct();
            window.clearTimeout(timer);
            timer = window.setTimeout(search, 220);
        });

        input.addEventListener("keydown", (event) => {
            const options = Array.from(results.querySelectorAll(".producto-opcion"));
            if (!options.length) return;
            const current = options.indexOf(document.activeElement);

            if (event.key === "ArrowDown") {
                event.preventDefault();
                options[Math.min(current + 1, options.length - 1)].focus();
            } else if (event.key === "Escape") {
                hideResults();
            }
        });

        results.addEventListener("keydown", (event) => {
            const options = Array.from(results.querySelectorAll(".producto-opcion"));
            const current = options.indexOf(document.activeElement);
            if (current < 0) return;

            if (event.key === "ArrowDown" || event.key === "ArrowUp") {
                event.preventDefault();
                const direction = event.key === "ArrowDown" ? 1 : -1;
                options[Math.max(0, Math.min(current + direction, options.length - 1))].focus();
            } else if (event.key === "Escape") {
                hideResults();
                input.focus();
            }
        });

        if (branch.matches("select")) {
            branch.addEventListener("change", () => {
                input.value = "";
                clearProduct();
                hideResults();
            });
        }

        form.addEventListener("submit", (event) => {
            if (!productId.value) {
                event.preventDefault();
                if (error) error.textContent = "Busca y selecciona un producto.";
                input.focus();
                search();
            }
        });

        document.addEventListener("click", (event) => {
            if (!results.contains(event.target) && event.target !== input) hideResults();
        });
    });
})();
