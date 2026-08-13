(() => {
    "use strict";

    const menu = document.querySelector("[data-profile-menu]");
    const panels = Array.from(document.querySelectorAll("[data-profile-panel]"));

    if (!menu || panels.length === 0) {
        return;
    }

    const links = Array.from(document.querySelectorAll("[data-profile-link]"));
    const panelIds = new Set(panels.map((panel) => panel.id));

    panels.forEach((panel) => {
        const shell = panel.querySelector(":scope > .public-shell");
        if (!shell) {
            return;
        }

        const backLink = document.createElement("a");
        backLink.className = "candidate-panel-back";
        backLink.href = "#menu-perfil";
        backLink.dataset.profileHome = "";
        backLink.innerHTML = '<span aria-hidden="true">←</span> Voltar ao perfil';
        shell.prepend(backLink);
    });

    const setCurrentLink = (activeId) => {
        links.forEach((link) => {
            const isCurrent = link.hash === `#${activeId}`;
            link.classList.toggle("is-current", isCurrent);
            if (isCurrent) {
                link.setAttribute("aria-current", "page");
            } else {
                link.removeAttribute("aria-current");
            }
        });
    };

    const showPanel = (id, shouldScroll) => {
        const activeId = panelIds.has(id) ? id : null;
        panels.forEach((panel) => {
            panel.hidden = panel.id !== activeId;
        });
        setCurrentLink(activeId);

        if (shouldScroll) {
            const target = activeId ? document.getElementById(activeId) : menu;
            target.scrollIntoView({ behavior: "smooth", block: "start" });
        }
    };

    links.forEach((link) => {
        link.addEventListener("click", (event) => {
            event.preventDefault();
            const id = link.hash.slice(1);
            history.pushState(null, "", link.hash);
            showPanel(id, true);
        });
    });

    document.querySelectorAll("[data-profile-home]").forEach((link) => {
        link.addEventListener("click", (event) => {
            event.preventDefault();
            history.pushState(null, "", "#menu-perfil");
            showPanel(null, true);
        });
    });

    window.addEventListener("popstate", () => {
        showPanel(window.location.hash.slice(1), true);
    });

    showPanel(window.location.hash.slice(1), Boolean(window.location.hash && window.location.hash !== "#menu-perfil"));
})();
