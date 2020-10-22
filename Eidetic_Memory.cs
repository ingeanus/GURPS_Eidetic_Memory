using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eidetic_Memory
{
    public partial class Eidetic_Memory : Form
    {
        public Dictionary<String, Materials> flexible_mats = new Dictionary<String, Materials>()
        {
            { "Energy Cloth", new Materials(12, 0.014, 1, 500, 500, 240, 120, "—", "F", "F/O", "") },
            { "Monocrys", new Materials(11, 0.018, 3, 150, 75, 184, 92, "—", "F", "F/O", "The full DR only applies vs. piercing and cutting damage.") },
            { "Retro-Reflective Armour",  new Materials(11, 0.0025, 10000000, 1500, 1500, 1666, 166, "—", "F", "F/O", "The armor’s DR only applies vs. microwave and (in cinematic games) \nvisible and near-infrared laser beams. It has 0 DR vs. other damage types.") },
            { "Bioplas", new Materials(10, 0.015, 3, 600, 300, 278, 92, "—", "B,F,T", "F/O", "The full DR only applies vs. piercing and burn damage.") },
            { "Nano-Ablative Polymer", new Materials(10, 0.012, 6, 150, 75, 275, 128, "—", "E,F", "F/O", "The full DR only applies against burning damage from lasers \n(including X-ray, gamma-ray, etc.).") },
            { "Advanced Nanoweave", new Materials(10, 0.024, 3, 150, 75, 138, 70, "—", "F", "F/O", "The full DR only applies vs. piercing and burn damage.") },
            { "Arachnoweave", new Materials(9, 0.03, 4, 600, 120, 96, 48, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Basic Nanoweave", new Materials(9, 0.03, 3, 750, 150, 110, 55, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.")},
            { "Laser-Ablative Polymer", new Materials(9, 0.018, 6, 150, 75, 128, 64, "—", "F,E", "F/O", "The full DR only applies against burning damage from lasers \n(including X-ray, gamma-ray, etc.).") },
            { "Magnetic Liquid Armour", new Materials(9, 0.032, 2, 200, 100, 90, 45, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Reflec", new Materials(9, 0.005, 10000000, 150, 150, 833, 83, "—", "F", "F/O", "The armor’s DR only applies vs. microwave and (in cinematic games) \nvisible and near-infrared laser beams. It has 0 DR vs. other damage types.") },
            { "STF Liquid Armour", new Materials(9, 0.032, 1, 150, 75, 90, 45, "—", "F", "F/O", "") },
            { "Aramid Fabric", new Materials(8, 0.04, 4, 240, 240, 58, 24, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage. \nThe #3/52 article MULTIPLIED damage vs pi and cut, in contrast to all other materials \nwhich DIVIDE against others. This was standardized to the other materials! Also, \nTL 6+ Construction methods were added in Pyramid #3/85, but I added them to this! \nIt's original is F/L not F/O!") },
            { "Ballistic Polymer", new Materials(8, 0.06, 2.5, 200, 50, 48, 24, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Improved Ballistic Polymer",  new Materials(8, 0.04, 2.5, 250, 100, 75, 36, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Kevlar",  new Materials(8, .1, 4, 80, 20, 33, 16, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Improved Kevlar",  new Materials(8, .08, 4, 120, 40, 40, 20, "—", "F", "F/O", "The full DR only applies against piercing and cutting damage.") },
            { "Improved Nomex",  new Materials(8, .055, 4, 35, 35, 10, 5, "—", "F", "F/O", "The full DR only applies against burning damage.") },
            { "Elastic Polymer",  new Materials(7, .16, 1, 100, 50, 16, 8, "—", "F", "F/O", "") },
            { "Nomex",  new Materials(7, .066, 4, 50, 25, 10, 5, "—", "F", "F/O", "The full DR only applies against burning damage.") },
            { "Nylon",  new Materials(7, .5, 1, 25, 6, 6, 3, "—", "F", "F/O", "")},
            { "Rubber",  new Materials(6, .45, 2, 5, 5, 14, 7, "—", "C,F,S", "F/O", "If assigned DR 2 or more, the full DR only applies against crushing damage.") },
            { "Cloth",  new Materials(0, .85, 1, 8, 8, 4, 4, "—", "C,F", "F", "") },
            { "Leather",  new Materials(0, .9, 1, 10, 10, 8, 4, "—", "F", "F/L/SC", "") },
            { "Silk",  new Materials(0, .85, 1, 100, 100, 4, 4, "—", "C,F", "F/L", "") }
        };

        public Dictionary<String, Materials> rigid_mats = new Dictionary<String, Materials>()
        {
            {"Hyperdense",  new Materials(12, 0.04, 1, 50, 50, 2083, 417, "10", "L", "R/S", "") },
            {"Hyperdense Laminate", new Materials(12, 0.02, 1, 200, 200, 1040, 278, "35", "L", "R/S", "") },
            {"Diamondoid", new Materials(11, 0.06, 1, 50, 25, 232, 93, "—", "T", "R/S", "") },
            {"Diamondoid Laminate", new Materials(11, 0.03, 1, 200, 100, 420, 168, "35", "L", "R/S", "")},
            {"Advanced Nano-Laminate", new Materials(10, 0.04, 1, 200, 100, 166, 66, "35", "L", "R/S", "")},
            {"Advanced Polymer Nanocomposite", new Materials(10, 0.08, 1, 50, 25, 104, 42, "—", "T", "R/S", "")},
            {"Electromagnetic Armour", new Materials(10, 0.01, 1, 100, 50, 666, 264, "35", "M", "R/S", "") },
            {"Ceramic Nanocomposite", new Materials(9, 0.1, 1, 300, 75, 166, 66, "—", "S", "S", "")  },
            {"Polymer Nanocomposite", new Materials(9, 0.1, 1, 400, 100, 83, 33, "—", "—", "R/S", "") },
            {"Titanium Nanocomposite", new Materials(9, 0.12, 1, 250, 25, 174, 70, "—", "S", "R/S", "") },
            {"Improved Ceramic", new Materials(8, 0.15, 1, 100, 20, 111, 44, "—", "S", "S", "") },
            {"Laminated Polycarbonate", new Materials(8, 0.25, 1, 25, 12, 12, 5, "—", "S,T", "S", "") },
            {"Polymer Composite", new Materials(8, 0.22, 1, 40, 10, 28, 11, "—", "—", "R/S", "") },
            {"Titanium Composite", new Materials(8, 0.2, 1, 250, 25, 104, 42, "—", "—", "R/S", "") },
            {"Ultra-Strength Steel", new Materials(8, 0.35, 1, 30, 8, 116, 23, "—", "—", "R/S", "") },
            {"Steel, Very Hard", new Materials(7, 0.45, 1, 20, 20, 94, 18, "—", "—", "R/S", "") },
            {"Titanium", new Materials(7, 0.4, 1, 50, 50, 57, 12, "—", "—", "R/S", "") },
            {"Basic Ceramic", new Materials(7, 0.2, 1, 25, 12, 83, 35, "—", "S", "S", "") },
            {"Ballistic Resin", new Materials(7, 0.55, 1, 2.5, 1, 15, 6, "—", "—", "R/S", "") },
            {"Fiberglass", new Materials(7, 0.6, 1, 8, 4, 17, 7, "—", "S", "R/S", "") },
            {"High-Strength Aluminum", new Materials(7, 0.4, 1, 12, 6, 35, 10, "—", "—", "R/S", "") },
            {"Plastic", new Materials(7, 0.75, 1, 1.80, 1.80, 12, 3, "—", "T", "R/S", "") },
            {"Polycarbonate", new Materials(7, 0.45, 1, 10, 5, 10, 3, "—", "S", "R/S", "") },
            {"Titanium Alloy", new Materials(7, 0.35, 1, 50, 10, 66, 20, "—", "—", "R/S", "") },
            {"Aluminum", new Materials(6, 0.45, 1, 15, 1, 31, 5, "—", "—", "R/S", "") },
            {"Hard Steel", new Materials(6, 0.5, 1, 3.50, 3.50, 82, 16, "—", "—", "R/S", "") },
            {"High-Strength Steel", new Materials(6, 0.58, 1, 3, 3, 70, 16, "—", "—", "R/S", "") },
            {"Steel, hard", new Materials(4, 0.5, 1, 250, 5, 81, 16, "—", "—", "R/S", "") },
            {"Steel, strong", new Materials(3, 0.58, 1, 50, 5, 70, 14, "—", "—", "R/S", "") },
            {"Iron, cheap", new Materials(2, 0.8, 1, 15, 3, 52, 10, "—", "—", "R/S", "") },
            {"Iron, good", new Materials(2, 0.6, 1, 25, 5, 68, 14, "—", "—", "R/S", "") },
            {"Lead", new Materials(2, 2, 1, 12.5, 2.5, 30, 4, "—", "—", "P/SC/S", "") },
            {"Adamnt", new Materials(1, 0.33, 1, 900, 180, 27, 15, "—", "S", "SC/S", "") },
            {"Orichalcum", new Materials(1, 0.2, 1, 3000, 600, 204, 41, "—", "—", "R/S", "") },
            {"Bronze, cheap", new Materials(1, 0.9, 1, 60, 12, 48, 9, "—", "—", "R/S", "") },
            {"Bronze, good", new Materials(1, 0.6, 1, 100, 20, 68, 14, "—", "—", "R/S", "") },
            {"Copper", new Materials(1, 1.6, 1, 80, 80, 30, 5, "—", "—", "R/S", "") },
            {"Jade", new Materials(1, 1.2, 1, 62.5, 62.5, 13, 5, "—", "S", "SC/S", "") },
            {"Jade, gem-quality", new Materials(1, 1.2, 1, 125, 125, 13, 5, "—", "S", "SC/S", "") },
            {"Stone", new Materials(1, 1.2, 1, 12.5, 12.5, 13, 5, "—", "S", "SC/S", "") },
            {"Bone", new Materials(0, 1, 1, 12.5, 12.5, 8, 4, "—", "S", "SC/S", "") },
            {"Horn", new Materials(0, 1, 1, 12.5, 12.5, 8, 4, "—", "S", "SC/S", "") },
            {"Wood", new Materials(0, 1.4, 1, 3, 3, 1.5, 2, "—", "C,S", "SC/S", "") }
        };

        public Dictionary<String, Constructions> flexible_constr = new Dictionary<String, Constructions>()
        {
            {"Fabric", new Constructions(0, 1, 1, 1) },
            {"Layered Fabric", new Constructions(0, 1.2, 1.5, 2)  },
            {"Impact Absorbing Fabric", new Constructions(6, 0.65, 5, 2) },
            {"Optimized Fabric", new Constructions(6, 0.8, 2, 2) }
        };

        public Dictionary<String, Constructions> rigid_constr = new Dictionary<String, Constructions>()
        {
            {"Plate", new Constructions(1, 0.8, 5, 3) },
            {"Scale", new Constructions(1, 1.1, 0.8, 2) },
            {"Solid", new Constructions(1, 1, 1, 2) },
            {"Mail", new Constructions(2, 0.9, 1.2, 2) },
            {"Segmented Plate", new Constructions(2, 1.45, 1.5, 3) }
        };

        public Dictionary<String, List<String>> mat_constr_methods = new Dictionary<String, List<String>>()
        {
            {"Fabric", new List<string>(){"F", "F/O", "F/L", "F/L/SC"} },
            {"Layered Fabric", new List<string>(){"F/O", "F/L", "F/L/SC"} },
            {"Impact Absorbing Fabric", new List<string>(){"F", "F/O", "F/L/SC", } },
            {"Optimized Fabric", new List<string>(){"F/O"} },
            {"Plate", new List<string>(){"R/S", "P/SC/S"} },
            {"Scale", new List<string>(){"R/S", "SC/S", "F/L/SC", "P/SC/S"} },
            {"Solid", new List<string>(){"R/S", "SC/S" , "S", "P/SC/S"} },
            {"Mail", new List<string>(){"R/S"} },
            {"Segmented Plate", new List<string>(){"R/S", "P/SC/S"} }
        };

        public Dictionary<String, String> note_desc = new Dictionary<string, string>()
        {
            {"F", "The armour material is flexible if it has no more than 25% of its rated DR per inch. \nFlexible armour provides flexible DR, but can be donned in 2/3 the usual time.\n" },
            {"S", "The armour is semi-ablative.\n" },
            {"C", "The armour is combustible. If DR is penetrated by burning damage it can catch fire. \nTreat the armour as resistant to fire (B433).\n" },
            {"E", "The armour is energy-ablatve. Treat the armour as ablative DR vs damage from \nlasers, plasma, fusion guns, or flamers.\n" },
            {"T", "The armour CAN be transparent at double material cost. \nIf transparent, it has 0 DR against visible light laser beams and against any blinding attack.\n" },
            {"B", "The armour is biotech, capable of sealing punctures and rips. In addition, at DR 15+ bioplas \ncan greatly reduce the cost of weight of an extended life-support system.\n" },
            {"L", "The armour is compodite laminate. If the armour has at least half the max DR, \nit will be doubled against shaped-charge warheads and plasma bolts.\n" },
            {"M", "The armour is electromagnetic. Its DR protects only against shaped-charge and \nplasma bolt weapons. Attacks failing to penetrate the DR of any armour \ninstalled over the EM armour don't trigger the EM.\n" }
        };

        public Dictionary<String, Beams> beam_types = new Dictionary<string, Beams>()
        {
            { "Disintegrator", new Beams(12, 12, "inf", "cor", 32, 0.7, 6.25, 25, 100, 400, 3, 400000, 6) },
            { "Graser", new Beams(12, 12, "10", "tight burn, sur", 3, 6000, 28, 112, 450, 1800, 3, 1500, 6) },
            { "Mind Disrupter", new Beams(12, 12, "contact", "aff", 2.75, 2.5, 27.8125, 111.25, 445, 1780, 3, 1780, 6) },
            { "Pulsar", new Beams(11, 12, "3", "cr exp, rad, sur", 6, 8, 135, 540, 2160, 8640, 2, 3000, 5) },
            { "Rainbow Laser", new Beams(11, 11, "3", "tight burn", 3, 56, 112.5, 450, 1800, 7200, 3, 500, 6) },
            { "X-Ray Laser", new Beams(11, 11, "5", "tight burn, sur", 3, 2000, 112.5, 450, 1800, 7200, 3, 1000, 6) },
            { "Graviton Beam", new Beams(11, 11, "inf", "cr, nokb", 1.5, 100, 14, 56, 225, 900, 3, 2000, 6) },
            { "Neural Disrupter", new Beams(11, 11, "contact", "aff", 2.75, 2.5, 111.25, 445, 1780, 7120, 3, 1780, 6) },
            { "Plasma Gun", new Beams(11, 11, "2", "burn, sur", 7.5, 6.7, 1031.25, 4125, 16500, 66000, 3, 16500, 4) },
            { "Blaster", new Beams(10, 11, "5", "tight burn, sur", 3, 32, 34, 135, 540, 2160, 3, 2000, 5) },
            { "Neutral Particle Beam", new Beams(10, 11, "1", "tight burn, sur, rad", 3, 32, 17, 68, 270, 1080, 3, 3000, 5) },
            { "Force Beam", new Beams(10, 10, "1", "cr, dbkb", 4, 11, 270, 1080, 4320, 17280, 4, 500, 6) },
            { "Sonic Stunner", new Beams(10, 10, "5", "aff", 2.75, 3.5, 445, 1780, 7120, 28480, 3, 1780, 3) },
            { "Laser", new Beams(9, 9, "2", "tight burn", 3, 40, 225, 900, 3600, 14400, 3, 500, 6) },
            { "Electrolaser", new Beams(9, 9, "2", "aff", 3.3, 5, 2300, 9200, 36800, 147200, 3, 2300, 4) },
            { "Sonic Screamer", new Beams(9, 9, "1", "aff", 2.75, 2, 1780, 7120, 28480, 113920, 3, 1780, 3) },
            { "Plasma Flamer", new Beams(9, 9, "1", "burn", 3, 2, 1780, 7120, 28480, 113920, 3, 1780, 0) },
        };

        public Dictionary<String, Focuses> focus_arrays = new Dictionary<string, Focuses>()
        {
            { "Tiny", new Focuses(0.1, 0.25) },
            { "Very Small", new Focuses(0.25, 0.5) },
            { "Small", new Focuses(0.5, 0.8) },
            { "Medium", new Focuses(1, 1) },
            { "Large", new Focuses(1.5, 1.25) },
            { "Very Large", new Focuses(2, 1.6) },
            { "Extremely Large", new Focuses(4, 2) }
        };

        public Dictionary<String, Generators> generator_options = new Dictionary<string, Generators>()
        {
            { "Single Shot", new Generators(1, 1, 1) },
            { "Semi Automatic", new Generators(3, 1.25, 1) },
            { "Light Automatic", new Generators(10, 1.25, 2) },
            { "Heavy Automatic", new Generators(20, 2, 2) },
            { "Gatling", new Generators(20, 2, 2) }
        };

        public Dictionary<String, Configurations> configuration_options = new Dictionary<string, Configurations>()
        {
            { "Beamer", new Configurations(0.5, 3.3, 1) },
            { "Pistol", new Configurations(1, 3.3, 1.25) },
            { "Rifle", new Configurations(2, 2.2, 1.5) },
            { "Cannon", new Configurations(3, 2.4, 1.5) }
        };
        

        public Eidetic_Memory()
        {
            InitializeComponent();
            get_Armour_Materials();
            get_Beam_Types();
        }

        private void calculate_surface_area()
        {
            decimal sa_mult = num_samult.Value;
            double sa = 0;

            if (cb_skull.Checked) { sa += 1.4; }
            if (cb_face.Checked) { sa += 0.7; }
            if (cb_neck.Checked) { sa += 0.35; }
            if (cb_chest.Checked) { sa += 5.25; }
            else if (cb_vitals.Checked) { sa += 1; }
            if (cb_abdomen.Checked) { sa += 1.75; }
            else if (cb_groin.Checked) { sa += 0.35; }
            if (cb_rshoulder.Checked) { sa += 0.35; }
            if (cb_ruparm.Checked) { sa += 0.35; }
            if (cb_relbow.Checked) { sa += 0.175; }
            if (cb_rforearm.Checked) { sa += 0.875; }
            if (cb_lshoulder.Checked) { sa += 0.35; }
            if (cb_luparm.Checked) { sa += 0.35; }
            if (cb_lelbow.Checked) { sa += 0.175; }
            if (cb_lforearm.Checked) { sa += 0.875; }
            if (cb_rhand.Checked) { sa += 0.35; }
            if (cb_lhand.Checked) { sa += 0.35; }
            if (cb_rthigh.Checked) { sa += 1.575; }
            if (cb_rknee.Checked) { sa += 0.175; }
            if (cb_rshin.Checked) { sa += 1.75; }
            if (cb_lthigh.Checked) { sa += 1.575; }
            if (cb_lknee.Checked) { sa += 0.175; }
            if (cb_lshin.Checked) { sa += 1.75; }
            if (cb_rfoot.Checked) { sa += 0.35; }
            if (cb_lfoot.Checked) { sa += 0.35; }
            num_surfacearea.Value = Convert.ToDecimal(sa) * sa_mult;
        }

        private void cb_rarm_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_rarm.Checked;
            cb_rshoulder.Checked = check;
            cb_ruparm.Checked = check;
            cb_relbow.Checked = check;
            cb_rforearm.Checked = check;

            calculate_surface_area();
        }

        private void cb_larm_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_larm.Checked;
            cb_lshoulder.Checked = check;
            cb_luparm.Checked = check;
            cb_lelbow.Checked = check;
            cb_lforearm.Checked = check;

            calculate_surface_area();
        }

        private void cb_torso_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_torso.Checked;
            cb_chest.Checked = check;
            cb_abdomen.Checked = check;

            calculate_surface_area();
        }

        private void cb_chest_CheckedChanged(object sender, EventArgs e)
        {
            cb_vitals.Checked = cb_chest.Checked;

            calculate_surface_area();
        }

        private void cb_abdomen_CheckedChanged(object sender, EventArgs e)
        {
            cb_groin.Checked = cb_abdomen.Checked;

            calculate_surface_area();
        }

        private void cb_head_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_head.Checked;
            cb_skull.Checked = check;
            cb_face.Checked = check;

            calculate_surface_area();
        }

        private void cb_rleg_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_rleg.Checked;
            cb_rthigh.Checked = check;
            cb_rknee.Checked = check;
            cb_rshin.Checked = check;
            cb_legpiece.Visible = check;

            calculate_surface_area();
        }

        private void cb_lleg_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_lleg.Checked;
            cb_lthigh.Checked = check;
            cb_lknee.Checked = check;
            cb_lshin.Checked = check;
            cb_legpiece.Visible = check;

            calculate_surface_area();
        }
        
        private void cb_rhand_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lhand_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lfoot_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rfoot_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_vitals_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_groin_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void num_weight_Leave(object sender, EventArgs e)
        {
            double scale = Math.Pow(Decimal.ToDouble(num_weight.Value/150), (2.0/3.0));
            num_samult.Value = Convert.ToDecimal(scale);
        }

        private void num_samult_Leave(object sender, EventArgs e)
        {
            double scale = 150 * Math.Pow(Decimal.ToDouble(num_samult.Value), (3.0/2.0));
            num_weight.Value = Convert.ToDecimal(scale);
            calculate_surface_area();
        }

        private void num_armourTL_ValueChanged(object sender, EventArgs e)
        {
            get_Armour_Materials();
            get_Armour_Construction();
            get_Concealability();
        }

        private void cb_rigid_CheckedChanged(object sender, EventArgs e)
        {
            get_Armour_Materials();
            get_Armour_Construction();
        }

        private void box_constr_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Construction_Stats();
            get_ArmourDR();
            get_Construction_Warnings();
            get_Cost();
        }

        private void box_armourmat_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Material_Stats();
            get_Armour_Construction();
            get_Concealability();
            get_ArmourDR();
            get_Cost();
            get_Construction_Warnings();
        }

        private void num_DR_ValueChanged(object sender, EventArgs e)
        {
            get_ArmourDR();
            get_Concealability();
        }

        private void num_armourweight_ValueChanged(object sender, EventArgs e)
        {
            get_ArmourWeight();
            get_Concealability();
            get_Cost();
        }

        private void num_cost_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cb_neck_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_skull_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_face_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rshoulder_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_ruparm_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_relbow_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rforearm_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lshoulder_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_luparm_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lelbow_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_lforearm_CheckedChanged(object sender, EventArgs e)
        {
            calculate_surface_area();
        }

        private void cb_rthigh_CheckedChanged(object sender, EventArgs e)
        {
            cb_legpiece.Visible = cb_rthigh.Checked;
            calculate_surface_area();
        }

        private void cb_rknee_CheckedChanged(object sender, EventArgs e)
        {
            cb_legpiece.Visible = cb_rknee.Checked;
            calculate_surface_area();
        }

        private void cb_rshin_CheckedChanged(object sender, EventArgs e)
        {
            cb_legpiece.Visible = cb_rshin.Checked;
            calculate_surface_area();
        }

        private void cb_lthigh_CheckedChanged(object sender, EventArgs e)
        {
            cb_legpiece.Visible = cb_lthigh.Checked;
            calculate_surface_area();
        }

        private void cb_lknee_CheckedChanged(object sender, EventArgs e)
        {
            cb_legpiece.Visible = cb_lknee.Checked;
            calculate_surface_area();
        }

        private void cb_lshin_CheckedChanged(object sender, EventArgs e)
        {
            cb_legpiece.Visible = cb_lshin.Checked;
            calculate_surface_area();
        }

        private void num_surfacearea_ValueChanged(object sender, EventArgs e)
        {
            get_ArmourDR();
        }

        private void cb_multtomax_CheckedChanged(object sender, EventArgs e)
        {
            get_Material_Stats();
        }

        private void cb_full_CheckedChanged(object sender, EventArgs e)
        {
            bool check = cb_full.Checked;
            cb_head.Checked = check;
            cb_neck.Checked = check;
            cb_torso.Checked = check;
            cb_rarm.Checked = check;
            cb_larm.Checked = check;
            cb_rhand.Checked = check;
            cb_lhand.Checked = check;
            cb_rleg.Checked = check;
            cb_lleg.Checked = check;
            cb_rfoot.Checked = check;
            cb_lfoot.Checked = check;

            calculate_surface_area();
        }

        private void get_Armour_Materials()
        {
            decimal TL = num_armourTL.Value;

            box_armourmat.Items.Clear();

            if (cb_rigid.Checked)
            {
                foreach (var material in rigid_mats)
                {
                    if (TL >= material.Value.TL)
                    {
                        box_armourmat.Items.Add(material.Key);
                    }
                }
            }
            else
            {
                foreach (var material in flexible_mats)
                {
                    if (TL >= material.Value.TL)
                    {
                        box_armourmat.Items.Add(material.Key);
                    }
                }
            }
        }

        private void get_Armour_Construction()
        {
            decimal TL = num_armourTL.Value;
            Materials mat;

            box_constr.Items.Clear();

            if (cb_rigid.Checked)
            {
                try
                {
                    mat = rigid_mats[box_armourmat.Text];

                    foreach (var constr in rigid_constr)
                    {
                        if (TL >= constr.Value.TL && mat_constr_methods.ContainsKey(constr.Key) && mat_constr_methods[constr.Key].Contains(mat.construction))
                        {
                            box_constr.Items.Add(constr.Key);
                        }
                    }
                }
                catch (Exception e)
                {
                    
                }
            }
            else
            {
                try
                {
                    mat = flexible_mats[box_armourmat.Text];

                    foreach (var constr in flexible_constr)
                    {
                        if (TL >= constr.Value.TL && mat_constr_methods.ContainsKey(constr.Key) && mat_constr_methods[constr.Key].Contains(mat.construction))
                        {
                            box_constr.Items.Add(constr.Key);
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        private void get_Material_Stats()
        {
            String cur_mat = box_armourmat.Text;
            decimal cur_TL = num_armourTL.Value;
            Materials mat;

            if (cb_rigid.Checked)
            {
                mat = rigid_mats[cur_mat];
            }
            else
            {
                mat = flexible_mats[cur_mat]; // Access from clicking checkbox 
            }

            lab_nummatTL.Text = mat.TL.ToString();
            lab_numWM.Text = mat.WM.ToString();
            if (cur_TL > mat.TL && cur_TL >= 5) // Checks to see if it is a high enough TL to lower cost. As well, in Low Tech this only happens at TL 5+ (and again at 6+ for steel which is accounted below).
            {
                if (cur_TL >= 6 && (cur_mat == "Steel, strong" || cur_mat == "Steel, hard"))
                {
                    lab_numCM.Text = (mat.highTLCM / 5).ToString(); // Divides by 5 again for TL 6+ getting the 1/25 cost.
                }
                else
                {
                    lab_numCM.Text = mat.highTLCM.ToString();
                }
            }
            else
            {
                lab_numCM.Text = mat.CM.ToString();
            }
            lab_numdrin.Text = mat.DRin.ToString();
            if (cb_multtomax.Checked)
            {
                lab_nummaxdr.Text = Math.Ceiling((mat.maxDR * num_samult.Value)).ToString();
            }
            else
            {
                lab_nummaxdr.Text = mat.maxDR.ToString();
            }
            lab_nummindr.Text = mat.minDR;
            lab_numnotes.Text = mat.notes;
            lab_numconstroptions.Text = mat.construction;
            lab_footnotes.Text = "";
            foreach (string key in note_desc.Keys)
            {
                if (mat.notes.Contains(key))
                {
                    lab_footnotes.Text = lab_footnotes.Text + note_desc[key];
                }
            }
            lab_footnotes.Text = lab_footnotes.Text + mat.footnotes;
            tt_armour.SetToolTip(lab_notes, mat.footnotes);
        }

        private void get_Construction_Stats()
        {
            string cur_constr = box_constr.Text;
            Constructions constr;

            try
            {
                if (cb_rigid.Checked)
                {
                    constr = rigid_constr[cur_constr];
                }
                else
                {
                    constr = flexible_constr[cur_constr];
                }

                lab_numCW.Text = constr.CW.ToString();
                lab_numCC.Text = constr.CC.ToString();
                lab_numconstrminDR.Text = constr.minDR.ToString();
            }
            catch (Exception e)
            {

            }
        }

        private void get_Concealability()
        {
            decimal dr = num_DR.Value;
            decimal maxdr = Decimal.Parse(lab_nummaxdr.Text);
            if (!cb_rigid.Checked)
            {
                if (dr > maxdr / 2)
                {
                    lab_numconceal.Text = "Not Concealable :: Heavy Clothing.";
                }
                else if (dr > maxdr / 4)
                {
                    lab_numconceal.Text = "Concealable :: Normal or Under Clothing.";
                }
                else if (dr > maxdr / 6)
                {
                    lab_numconceal.Text = "Very Concealable :: Light Clothing.";
                }
                else if (dr > 0)
                {
                    lab_numconceal.Text = "Extremely Concealable :: Very Light Clothing.";
                }
                else
                {
                    lab_numconceal.Text = "";
                }
            }
            else
            {
                lab_numconceal.Text = "Not Concealable :: Rigid Armour.";
            }
        }

        private void get_ArmourDR()
        {
            decimal sa = num_surfacearea.Value;
            decimal wm = Decimal.Parse(lab_numWM.Text);
            decimal cw = Decimal.Parse(lab_numCW.Text);
            decimal dr = num_DR.Value;

            num_armourweight.Value = sa * wm * cw * dr;
        }

        private void get_ArmourWeight()
        {

            decimal weight = num_armourweight.Value;
            decimal sa = num_surfacearea.Value;
            decimal wm = Decimal.Parse(lab_numWM.Text);
            decimal cw = Decimal.Parse(lab_numCW.Text);

            if (sa * wm * cw == 0)
            {
                num_DR.Value = 0;
            }
            else
            {
                num_DR.Value = weight / (sa * wm * cw);
            }
        }

        private void get_Cost()
        {
            decimal weight = num_armourweight.Value;
            decimal cm = Decimal.Parse(lab_numCM.Text);
            decimal cc = Decimal.Parse(lab_numCC.Text);

            num_cost.Value = weight * cm * cc;
        }

        private void get_Construction_Warnings()
        {
            String constr = box_constr.Text;
            String mat = box_armourmat.Text;
            if ((constr == "Solid" || constr == "Plate") && (mat == "Iron, cheap" || mat == "Iron, good" || mat == "Steel, strong"))
            {
                lab_constrwarn.Text = "Construction requires TL 4 for any body part except head!";
            }
            else if (constr == "Layered Fabric" && mat == "Leather")
            {
                lab_constrwarn.Text = "Construction requires TL 1 for Layered Leather!";
            }
            else
            {
                lab_constrwarn.Text = "";
            }
        }

        private String return_locations()
        {
            String location_string = "";
            List<String> locations = new List<string>();

            if (cb_head.Checked) locations.Add("Head");
            else
            {
                if (cb_skull.Checked) locations.Add("Skull");
                else if (cb_face.Checked) locations.Add("Face");
            }
            if (cb_neck.Checked) locations.Add("Neck");
            if (cb_torso.Checked) locations.Add("Torso");
            else
            {
                if (cb_chest.Checked) locations.Add("Chest");
                if (cb_vitals.Checked) locations.Add("Vitals"); // While chest DOES imply Vitals are covered, often I've seen these noted independantly, so I will do so as well.
                if (cb_abdomen.Checked) locations.Add("Abdomen");
                else if (cb_groin.Checked) locations.Add("Groin");
            }
            if (cb_rarm.Checked) locations.Add("Right Arm");
            else
            {
                if (cb_rshoulder.Checked) locations.Add("Right Shoulder");
                if (cb_ruparm.Checked) locations.Add("Right Upper Arm");
                if (cb_relbow.Checked) locations.Add("Right Elbow");
                if (cb_rforearm.Checked) locations.Add("Right Forearm");
            }
            if (cb_larm.Checked) 
            { 
                locations.Add(locations.Contains("Right Arm") ? "Arms" : "Left Arm");
                locations.Remove(locations.Contains("Right Arm") ? "Right Arm" : "");
            }
            else
            {
                if (cb_lshoulder.Checked)
                {
                    locations.Add(locations.Contains("Right Shoulder") ? "Shoulders" : "Left Shoulder");
                    locations.Remove(locations.Contains("Right Shoulder") ? "Right Shoulder" : "");
                }
                if (cb_luparm.Checked)
                {
                    locations.Add(locations.Contains("Right Upper Arm") ? "Upper Arms" : "Left Upper Arm");
                    locations.Remove(locations.Contains("Right Upper Arm") ? "Right Upper Arm" : "");
                }
                if (cb_lelbow.Checked)
                {
                    locations.Add(locations.Contains("Right Elbow") ? "Elbows" : "Left Eblow");
                    locations.Remove(locations.Contains("Right Elbow") ? "Right Elbow" : "");
                }
                if (cb_lforearm.Checked)
                {
                    locations.Add(locations.Contains("Right Forearm") ? "Forearms" : "Left Forearm");
                    locations.Remove(locations.Contains("Right Forearm") ? "Right Forearm" : "");
                }
            }
            if (cb_rhand.Checked) locations.Add("Right Hand");
            if (cb_lhand.Checked)
            {
                locations.Add(locations.Contains("Right Hand") ? "Hands" : "Left Hand");
                locations.Remove(locations.Contains("Right Hand") ? "Right Hand" : "");
            }
            if (cb_rleg.Checked) locations.Add("Right Leg");
            else
            {
                if (cb_rthigh.Checked) locations.Add("Right Thigh");
                if (cb_rknee.Checked) locations.Add("Right Knee");
                if (cb_rshin.Checked) locations.Add("Right Shin");
            }
            if (cb_lleg.Checked)
            {
                locations.Add(locations.Contains("Right Leg") ? "Legs" : "Left Leg");
                locations.Remove(locations.Contains("Right Leg") ? "Right Leg" : "");
            }
            else
            {
                if (cb_lthigh.Checked)
                {
                    locations.Add(locations.Contains("Right Thigh") ? "Thighs" : "Left Thigh");
                    locations.Remove(locations.Contains("Right Thigh") ? "Right Thigh" : "");
                }
                if (cb_lknee.Checked) 
                { 
                    locations.Add(locations.Contains("Right Knee") ? "Knees" : "Left Knee");
                    locations.Remove(locations.Contains("Right Knee") ? "Right Knee" : "");
                }
                if (cb_lshin.Checked)
                {
                    locations.Add(locations.Contains("Right Shin") ? "Shins" : "Left Shin");
                    locations.Remove(locations.Contains("Right Shin") ? "Right Shin" : "");
                }
            }
            if (cb_rfoot.Checked) locations.Add("Right Foot");
            if (cb_lfoot.Checked)
            {
                locations.Add(locations.Contains("Right Foot") ? "Feet" : "Left Foot");
                locations.Remove(locations.Contains("Right Foot") ? "Right Foot" : "");
            }

            foreach (String s in locations)
            {
                location_string += s + ", ";
            }

            location_string = location_string.Substring(0, location_string.Length - 2);

            return location_string;
        }

        private void btn_save1_Click(object sender, EventArgs e)
        {
            bool rigid = cb_rigid.Checked;
            Materials mat = rigid ? rigid_mats[box_armourmat.Text] : flexible_mats[box_armourmat.Text]; // Gets the material type currently selected using Ternary Operators.

            if (mat.drdivisor > 1)
            {
                lab_numsavedr1.Text = num_DR.Value.ToString() + "/" + Math.Floor((num_DR.Value / Convert.ToDecimal(mat.drdivisor))).ToString();
            }
            else
            {
                lab_numsavedr1.Text = num_DR.Value.ToString();
            }

            lab_numsaveweight1.Text = num_armourweight.Value.ToString("0.##") + " lbs.";
            lab_numsavecost1.Text = "$" + num_cost.Value.ToString("0.##");
            lab_numsaveconceal1.Text = lab_numconceal.Text;
            lab_numsavenotes1.Text = lab_numnotes.Text;
            lab_numsaveloc1.Text = return_locations();
        }

        private void btn_save2_Click(object sender, EventArgs e)
        {
            bool rigid = cb_rigid.Checked;
            Materials mat = rigid ? rigid_mats[box_armourmat.Text] : flexible_mats[box_armourmat.Text]; // Gets the material type currently selected using Ternary Operators.

            if (mat.drdivisor > 1)
            {
                lab_numsavedr2.Text = num_DR.Value.ToString() + "/" + Math.Floor((num_DR.Value / Convert.ToDecimal(mat.drdivisor))).ToString();
            }
            else
            {
                lab_numsavedr2.Text = num_DR.Value.ToString();
            }

            lab_numsaveweight2.Text = num_armourweight.Value.ToString("0.##") + " lbs.";
            lab_numsavecost2.Text = "$" + num_cost.Value.ToString("0.##");
            lab_numsaveconceal2.Text = lab_numconceal.Text;
            lab_numsavenotes2.Text = lab_numnotes.Text;
            lab_numsaveloc2.Text = return_locations();
        }

        private void btn_save3_Click(object sender, EventArgs e)
        {
            bool rigid = cb_rigid.Checked;
            Materials mat = rigid ? rigid_mats[box_armourmat.Text] : flexible_mats[box_armourmat.Text]; // Gets the material type currently selected using Ternary Operators.

            if (mat.drdivisor > 1)
            {
                lab_numsavedr3.Text = num_DR.Value.ToString() + "/" + Math.Floor((num_DR.Value / Convert.ToDecimal(mat.drdivisor))).ToString();
            }
            else
            {
                lab_numsavedr3.Text = num_DR.Value.ToString();
            }

            lab_numsaveweight3.Text = num_armourweight.Value.ToString("0.##") + " lbs.";
            lab_numsavecost3.Text = "$" + num_cost.Value.ToString("0.##");
            lab_numsaveconceal3.Text = lab_numconceal.Text;
            lab_numsavenotes3.Text = lab_numnotes.Text;
            lab_numsaveloc3.Text = return_locations();
        }

        private void btn_save4_Click(object sender, EventArgs e)
        {
            bool rigid = cb_rigid.Checked;
            Materials mat = rigid ? rigid_mats[box_armourmat.Text] : flexible_mats[box_armourmat.Text]; // Gets the material type currently selected using Ternary Operators.

            if (mat.drdivisor > 1)
            {
                lab_numsavedr4.Text = num_DR.Value.ToString() + "/" + Math.Floor((num_DR.Value / Convert.ToDecimal(mat.drdivisor))).ToString();
            }
            else
            {
                lab_numsavedr4.Text = num_DR.Value.ToString();
            }

            lab_numsaveweight4.Text = num_armourweight.Value.ToString("0.##") + " lbs.";
            lab_numsavecost4.Text = "$" + num_cost.Value.ToString("0.##");
            lab_numsaveconceal4.Text = lab_numconceal.Text;
            lab_numsavenotes4.Text = lab_numnotes.Text;
            lab_numsaveloc4.Text = return_locations();
        }

        private void num_blasterTL_ValueChanged(object sender, EventArgs e)
        {
            get_Beam_Types();
            get_Cell_Stats();
        }

        private void num_numpieces_ValueChanged(object sender, EventArgs e)
        {
            decimal num = num_numpieces.Value * 3 + ((cb_legpiece.Checked) ? ((cb_rigid.Checked) ? 12 : 3) : 0);

            lab_numdontime.Text = num.ToString();

            get_Weapon_Stats();
        }

        private void cb_legpiece_CheckedChanged(object sender, EventArgs e)
        {
            decimal num = num_numpieces.Value * 3 + ((cb_legpiece.Checked) ? ((cb_rigid.Checked) ? 12 : 3) : 0);

            lab_numdontime.Text = num.ToString();
        }

        private void damage_dice_data_ValueChanged(object sender, EventArgs e)
        {
            get_Empty_Weight();
            get_Weapon_Stats();
        }

        private void beam_type_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            affliction();
            get_Empty_Weight();
            get_Weapon_Stats();
            get_Cell_Stats();
        }

        private void box_focalarray_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Focus_Stats();
            get_Empty_Weight();
            get_Weapon_Stats();
        }

        private void box_generator_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Generator_Stats();
            get_Empty_Weight();
            get_Weapon_Stats();
        }

        private void box_conf_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Configuration_Stats();
            get_Weapon_Stats();
        }

        private void box_celltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Cell_Stats();
            get_Weapon_Stats();
        }

        private void cb_supersciencecell_CheckedChanged(object sender, EventArgs e)
        {
            get_Cell_Stats();
            get_Weapon_Stats();
        }

        private void num_cellTL_ValueChanged(object sender, EventArgs e)
        {
            get_Cell_Stats();
            get_Weapon_Stats();
        }

        private void num_numcells_ValueChanged(object sender, EventArgs e)
        {
            get_Cell_Stats();
            get_Weapon_Stats();
        }

        private void cb_nonrecharge_CheckedChanged(object sender, EventArgs e)
        {
            get_Cell_Stats();
            get_Weapon_Stats();
        }

        private void get_Empty_Weight()
        {
            try
            {
                double damage_dice = Decimal.ToDouble(num_damagedice.Value);
                double superscience = cb_superscienceweapon.Checked ? 0.5 : 1;
                Beams wep = beam_types[box_beamtype.Text];
                double focal_weight = Double.Parse(lab_numfocusweight.Text);
                double generator_weight = Double.Parse(lab_numgenweight.Text);

                double weight = Math.Pow(damage_dice * superscience / wep.weightDiv, 3) * focal_weight * generator_weight;

                num_emptyweight.Value = Convert.ToDecimal(weight);
            }
            catch (Exception e)
            {

            }
        }

        private void get_Beam_Types()
        {
            decimal TL = num_blasterTL.Value;

            box_beamtype.Items.Clear();

            foreach (var weapon in beam_types)
            {
                if (TL >= weapon.Value.TL)
                {
                    box_beamtype.Items.Add(weapon.Key);
                }
            }            
        }

        private void get_Focus_Stats()
        {
            Focuses foc = focus_arrays[box_focalarray.Text];

            lab_numfocusrange.Text = foc.range.ToString();
            lab_numfocusweight.Text = foc.weight.ToString();
        }

        private void get_Generator_Stats()
        {
            Generators gen = generator_options[box_generator.Text];

            lab_numgenrof.Text = gen.rof.ToString();
            lab_numgenweight.Text = gen.weight.ToString();
            lab_numgencost.Text = gen.cost.ToString();
        }

        private void get_Configuration_Stats()
        {
            Configurations conf = configuration_options[box_conf.Text];

            lab_numconfacc.Text = conf.accMult.ToString();
            lab_numconfstmult.Text = conf.stmult.ToString();
            lab_numconfbulkmult.Text = conf.bulkmult.ToString();
        }

        private bool affliction()
        {
            if (box_beamtype.Text == "Electrolaser" || box_beamtype.Text == "Sonic Screamer" || box_beamtype.Text == "Sonic Stunner" || box_beamtype.Text == "Neural Disrupter" || box_beamtype.Text == "Mind Disruptor")
            {
                lab_damagedice.Text = "Aff Penalty";
                return true;
            }
            else
            {
                lab_damagedice.Text = "Damage Dice";
                return false;
            }
        }

        private void get_Cell_Stats()
        {
            try
            {
                Beams beam = beam_types[box_beamtype.Text];
                int cellTL = Decimal.ToInt32(num_cellTL.Value);
                int num = Decimal.ToInt32(num_numcells.Value);
                double baseShots;
                bool superscience = cb_supersciencecell.Checked;
                bool highTL = (beam.TL < num_blasterTL.Value);
                bool nonRecharge = cb_nonrecharge.Checked;
                int size = box_celltype.SelectedIndex-2;

                if (cellTL == 9)
                {
                    baseShots = beam.shots1 * Math.Pow(10, size);
                    lab_numbaseshots.Text = (baseShots * num * (highTL ? 2 : 1) * (nonRecharge ? 2 : 1) * (superscience ? 5 : 1)).ToString();
                }
                else if (cellTL == 10)
                {
                    baseShots = beam.shots2 * Math.Pow(10, size);
                    lab_numbaseshots.Text = (baseShots * num * (highTL ? 2 : 1) * (nonRecharge ? 2 : 1) * (superscience ? 5 : 1)).ToString();
                }
                else if (cellTL == 11)
                {
                    baseShots = beam.shots3 * Math.Pow(10, size);
                    lab_numbaseshots.Text = (baseShots * num * (highTL ? 2 : 1) * (nonRecharge ? 2 : 1) * (superscience ? 5 : 1)).ToString();
                }
                else
                {
                    baseShots = beam.shots4 * Math.Pow(10, size);
                    lab_numbaseshots.Text = (baseShots * num * (highTL ? 2 : 1) * (nonRecharge ? 2 : 1) * (superscience ? 5 : 1)).ToString();
                }

                if (size <= 2)
                {
                    lab_numcellweight.Text = (Math.Pow(10, size) * 0.5 * num).ToString();
                }
                else
                {
                    lab_numcellweight.Text = (Math.Pow(10, size) * 0.02 * num).ToString();
                }

                if (size < 1)
                {
                    lab_numcellcost.Text = "$" + ((4 + size) * num).ToString();
                }
                else if (size < 3)
                {
                    lab_numcellcost.Text = "$" + (Math.Pow(10, size) * num).ToString();
                }
                else
                {
                    lab_numcellcost.Text = "$" + (Math.Pow(10, size) * 2 * num).ToString();
                }
            }
            catch (Exception e)
            {

            }
        }

        private void get_Weapon_Stats()
        {
            try
            {
                string beamType = box_beamtype.Text;
                Beams beam = beam_types[beamType];
                Focuses foc = focus_arrays[box_focalarray.Text];
                Generators gen = generator_options[box_generator.Text];
                Configurations conf = configuration_options[box_conf.Text];
                decimal dmg = num_damagedice.Value;
                double range;
                int cellIndex = box_celltype.SelectedIndex;
                String elec;

                if (dmg >= 8)
                {
                    elec = "1d-1";
                }
                else if (dmg >= 6)
                {
                    elec = "1d-2";
                }
                else
                {
                    elec = "1d-3";
                }

                if (affliction())
                {
                    lab_numdamage.Text = ((beamType == "Mind Disrupter" || beamType == "Neural Disrupter") ? "Will" : "HT") + "-" + Decimal.ToInt32(dmg) + ((beamType == "Electrolaser") ? " follow-up " + elec : "");
                }
                else
                {
                    lab_numdamage.Text = dmg.ToString() + "d" + ((beam.armourDiv != "inf" && Int32.Parse(beam.armourDiv) > 1) ? "(" + beam.armourDiv + ") " : ((beam.armourDiv == "inf") ? "(inf) " : " ")) + beam.type;
                }

                lab_numacc.Text = (beam.accMult * conf.accMult).ToString();

                range = Decimal.ToDouble(dmg * dmg) * beam.rangeMult * foc.range;
                lab_numrange.Text = (range).ToString() + "/" + (range * 3).ToString();

                lab_numrof.Text = gen.rof.ToString();

                lab_numshots.Text = Math.Floor(Double.Parse(lab_numbaseshots.Text) / Math.Pow( Decimal.ToDouble(dmg), 3)).ToString() + "(" + ((cellIndex > 2 ? 5 : 3) * num_numcells.Value).ToString() + ")";

                lab_numweaponweight.Text = (num_emptyweight.Value + Decimal.Parse(lab_numcellweight.Text)).ToString("0.##");

                lab_numST.Text = (Math.Sqrt(Double.Parse(lab_numweaponweight.Text)) * conf.stmult).ToString("0");

                lab_numbulk.Text = "-" + (Math.Sqrt(Double.Parse(lab_numweaponweight.Text)) * conf.bulkmult).ToString("0");

                lab_numrcl.Text = box_beamtype.Text == "Plasma Gun" ? "2" : "1";

                lab_numweaponcost.Text = "$" + (Decimal.ToDouble(num_emptyweight.Value) * beam.cost * gen.cost).ToString("0.##");

                lab_numLC.Text = (beam.LC + (Double.Parse(lab_numweaponweight.Text) > 5 ? ((Double.Parse(lab_numweaponweight.Text) > 15) ? -2 : -1) : 0)).ToString();
            }
            catch (Exception e)
            {

            }
        }

        
    }

    public class Materials
    {
        public int TL;
        public double WM;
        public double drdivisor;
        public double CM;
        public double highTLCM;
        public double DRin;
        public int maxDR;
        public String minDR;
        public String notes;
        public String construction;
        public String footnotes;

        public Materials(int tech, double weight, double div, double cost, double high, double dr, int max, String min, String n, String constr, String fn)
        {
            TL = tech;
            WM = weight;
            drdivisor = div;
            CM = cost;
            highTLCM = high;
            DRin = dr;
            maxDR = max;
            minDR = min;
            notes = n;
            construction = constr;
            footnotes = fn;
        }
    }

    public class Constructions
    {
        public int TL;
        public double CW;
        public double CC;
        public int minDR;

        public Constructions(int t, double w, double c, int dr)
        {
            TL = t;
            CW = w;
            CC = c;
            minDR = dr;
        }
    }

    public class Beams
    {
        public int TL;
        public int highTL;
        public String armourDiv;
        public String type;
        public double weightDiv;
        public double rangeMult;
        public double shots1;
        public double shots2;
        public double shots3;
        public double shots4;
        public int LC;
        public double cost;
        public double accMult;

        public Beams(int t, int ht, String div, String ty, double w, double r, double s1, double s2, double s3, double s4, int l, double c, double a)
        {
            TL = t;
            highTL = ht;
            armourDiv = div;
            type = ty;
            weightDiv = w;
            rangeMult = r;
            shots1 = s1;
            shots2 = s2;
            shots3 = s3;
            shots4 = s4;
            LC = l;
            cost = c;
            accMult = a;
        }
    }

    public class Focuses
    {
        public double range;
        public double weight;
        
        public Focuses(double r, double w)
        {
            range = r;
            weight = w;
        }
    }

    public class Generators
    {
        public int rof;
        public double weight;
        public int cost;

        public Generators(int r, double w, int c)
        {
            rof = r;
            weight = w;
            cost = c;
        }
    }

    public class Configurations
    {
        public double accMult;
        public double stmult;
        public double bulkmult;
    
        public Configurations(double a, double s, double b)
        {
            accMult = a;
            stmult = s;
            bulkmult = b;
        }
    }
}
